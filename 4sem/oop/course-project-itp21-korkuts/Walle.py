import socket # Модуль для работы с сокетами
import ASUS.GPIO as GPIO # Модуль для работы с пинами одноплатного компьютера ASUS tinkerboard
import freenect # Модуль для работы с кинектом
import cv2 # Модуль с алгоритмами машинного зрения
import numpy as np # Модуль, упрощающий и ускоряющий работу с массивами чисел
import signal # Модуль, необходимый для обработки событий
from time import sleep # Метод, необходимый для создания задержки во время исполнения

class Walle():
	# Конструктор класса Walle
	def __init__(self):
		try:
			self.n, self.m = freenect.sync_get_depth()[0].shape # Инициализация размеров изображения
		except:
			self.n, self.m = 480, 640
		self.obj = None
		self.remembered = False
		self.orb = cv2.ORB(nfeatures=500) # Инициализация экземпляра класса, реализующего алгоритм машинного обучения ORB
		print self.n, self.m
		
		
	# Инициализация пинов двигателей
	def GPIO_setup(self):
		GPIO.setmode(GPIO.BOARD) # Задаём режим стандартного одноплатника
		GPIO.setwarnings(False) # Убираем предупреждения
		GPIO.setup(5, GPIO.OUT) # motor2
		GPIO.setup(7, GPIO.OUT) # dir2
		GPIO.setup(35, GPIO.OUT) # motor4
		GPIO.setup(37, GPIO.OUT) # dir4
		GPIO.setup(8, GPIO.OUT) # motor1
		GPIO.setup(10, GPIO.OUT) # dir1
		GPIO.setup(38, GPIO.OUT) # motor3
		GPIO.setup(40, GPIO.OUT) # dir3
		self.motors = [8, 5, 38, 35]
		self.dirs = [10, 7, 40, 37]
		self.right_dirs = [10, 7]
		self.left_dirs = [40, 37]
	
	# Метод, останавливающий двигатели робота
	def stop_moving(self):
		for item in self.motors + self.dirs:
				GPIO.output(item, 0)
	
	# Метод, запускающий двигатели робота
	def launch_motors(self):
		for item in self.motors:
				GPIO.output(item, 1)
	
	# Метод активации режима передвижения вперёд
	def move_forward(self):
		self.launch_motors()
		for item in self.right_dirs:
			GPIO.output(item, 1)
		for item in self.left_dirs:
			GPIO.output(item, 0)
		
	# Метод активации режима передвижения назад
	def move_backward(self):
		self.launch_motors()
		for item in self.right_dirs:
			GPIO.output(item, 0)
		for item in self.left_dirs:
			GPIO.output(item, 1)
		
	# Метод активации режима передвижения влево
	def move_left(self):
		self.launch_motors()
		for item in self.dirs:
			GPIO.output(item, 1)
		
	# Метод активации режима передвижения вправо
	def move_right(self):
		self.launch_motors()
		for item in self.dirs:
			GPIO.output(item, 0)
	
	# Деактивация двигателей
	def GPIO_clear(self):
		for item in self.motors + self.dirs:
			GPIO.output(item, 0)
	
	# Метод, реализующий соединение с устройством
	def connection_setup(self, port=9091):
		sock = socket.socket() # Создание экземпляра класса socket
		sock.bind(('', port)) # Присвоение сокету параметров
		sock.listen(1) # Прослушивание сокета на одно подключение
		conn, addr = sock.accept() # Активация соединения с мобильным устройством
		print 'connected: ', addr
		self.socket = sock
		self.connection = conn
	
	# Метод, закрывающий соединение с устройством
	def connection_close(self):
		self.connection = None
		self.socket.close()
		print ("Bye.")
			
	# Метод, получающий удобное для вывода на экран представление массива глубины
	def pretty_depth(self, depth):
		np.clip(depth, 0, 2**10 - 1, depth)
		depth >>= 2
		depth = depth.astype(np.uint8)
		return depth
		
	# Метод конвертирующий изображение из формата BGR в формат RGB
	def rgb_video(self, video):
		return video[:, :, ::-1]  # BGR -> RGB
	
	# Метод, возвращающий индексы разделения экрана на 9 равных частей
	def fields_of_vision_idxs(self):
		left_top_idxs = ((0, self.n//3), (0, self.m//3))
		center_top_idxs = ((0, self.n//3), (self.m//3 ,2 * self.m // 3))
		right_top_idxs = ((0, self.n//3), (2 * self.m // 3, self.m))
		left_center_idxs = ((self.n//3 ,2 * self.n // 3), (0, self.m//3))
		center_center_idxs = ((self.n//3 ,2 * self.n // 3), (self.m//3 ,2 * self.m // 3))
		right_center_idxs = ((self.n//3 ,2 * self.n // 3), (2 * self.m // 3, self.m))
		left_bottom_idxs = ((2 * self.n // 3, self.n), (0, self.m//3))
		center_bottom_idxs = ((2 * self.n // 3, self.n), (self.m//3 ,2 * self.m // 3))
		right_bottom_idxs = ((2 * self.n // 3, self.n), (2 * self.m // 3, self.m))
		return (left_top_idxs, center_top_idxs, right_top_idxs,
				left_center_idxs, center_center_idxs, right_center_idxs,
				left_bottom_idxs, center_bottom_idxs, right_bottom_idxs)
		
	# Метод, показывающий в какой области экрана есть препятствие если оно есть
	def is_smth_near(self, frame):
		stop_factor = False
		stop_index = ''
		for i, field in enumerate(self.fields_of_vision_idxs()):
			if np.sum(frame[field[0][0]: field[0][1], field[1][0]: field[1][1]]) / (self.n * self.m / 9) > 1500:
				stop_factor = True
				stop_index = i
		return stop_index + 1 if stop_factor else False

	# Основной метод класса, где происходит циклическая обработка команд, поступающих с мобильного устройства		
	def program(self):
		try:
			def handler(signum, frame): # Обработка события прерывания выполнения программы
				self.GPIO_clear()
				self.connection_close()
				sys.exit()
			signal.signal(signal.SIGTSTP, handler)
			self.GPIO_setup()
			self.connection_setup()
			while True:
				try:
					cv2.imshow('Video', freenect.sync_get_video()[0])
				except:
					print 'Something with kinect'
				data = self.connection.recv(1024) # Получение данных по открытому соединению
				data = data.decode("UTF-16") # Декодирования данных из формата UTF-16
				print data
				if not data or data == 'Close connection':
					raise Exception("There is no some data")
				elif data == 'Auto':
					try:
						self.autopilot() # Переход в режим автоматического управления
					except:
						print 'Something with kinect'
				elif data == 'Remember':
					try:
						self.object_remember(freenect.sync_get_video()[0]) # Запоминание объекта
					except:
						print 'Something with kinect'	
				elif data == 'Forward':
					self.move_forward()
				elif data == 'Backward':
					self.move_backward()
				elif data == 'Left':
					self.move_left()
				elif data == 'Right':
					self.move_right()
				elif data == 'Stop':
					self.stop_moving()
		except Exception as e:
			print 'Error: ', e
			self.GPIO_clear()
			try:
				self.connection_close()
			except Exception as e:
				print e
	
	def autopilot(self):
		current_dir = 'ForwardStart'
		self.move_forward()
		while True:
			data = self.connection.recv(1024) # Получение данных
			data = data.decode('UTF-16')
			if not data.endswith('Auto'): # Пока последние полученные данные равняются "Auto" продолжаем автоматическое управление
				self.stop_moving() # Как только последние данные не "Auto" заканчиваем движение и возвращаемся в главный метод
				return
			near = self.is_smth_near(freenect.sync_get_depth()[0]) # Проверка, есть ли рядом объекты
			self.search_for_remmembered_object(freenect.sync_get_video()[0]) # Поиск запомненного объекта
			if near:
				if near in [1, 4, 7]:
					cv2.imshow('Video', freenect.sync_get_video()[0])
					if current_dir != 'RightStart':
						print 'RightStart'
						current_dir = 'RightStart'
						self.move_right()
				else:
					cv2.imshow('Video', freenect.sync_get_video()[0])
					if current_dir != 'LeftStart':
						print 'LeftStart'
						current_dir = 'LeftStart'
						self.move_left()
			else:
				cv2.imshow('Video', freenect.sync_get_video()[0])
				if current_dir != 'ForwardStart':
					print 'ForwardStart'
					current_dir = 'ForwardStart'
					self.move_forward()
			if cv2.waitKey(10) == 27:
				break
				
	# Метод, запоминающий объект
	def object_remember(self, image):
		self.obj = self.orb.detectAndCompute(image, None) # Инициализация ключевых точек и их дескрипторов
		img_key = cv2.drawKeypoints(image, self.obj[0], color=(0, 255, 0), flags=0) # Рисование ключевых точек на изображении для дальнейшего вывода
		cv2.imshow('Object' ,img_key)
		self.remembered = True
	
	def search_for_remmembered_object(self, image):
		if self.remembered == True: # Если есть запомненный объект
			scene = self.orb.detectAndCompute(image, None) # Обработка сцены
			good_matches = self.findMatches(self.obj[1], scene[1]) # Сравнение объекта и сцены на наличие похожих особых точек
			print str(round(len(good_matches) / 500. * 1000 / 7, 1)) + "%" # Вывод вероятности
		else:
			print 'You should remember object at first'
		
	def findMatches(self, desc1, desc2):
		index_params= dict(algorithm = 6,
						 table_number = 12,
						 key_size = 20,
						 multi_probe_level = 2) # Задание параметров поиска совпадений
		search_params = dict(checks=500)
		flann = cv2.FlannBasedMatcher(index_params,search_params) # Инициализация экземпляра объекта для сравнения особых точек
		matches = flann.knnMatch(desc1,desc2, 2) # Нахождение совпадений между объектом и сценой
		good = []
		for m in matches:
			if len(m) > 0 and m[0].distance < 0.7*m[-1].distance:
				good.append(m[0])
		return good 
					
# При запуске программы, инициализируется класс Walle и запускается основной исполняемый метод
if __name__ == '__main__':
	walle = Walle()
	walle.program()

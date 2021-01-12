def open_txt_recs(file_name):
    records = []
    keys = []
    with open(file_name) as file:
        keys = file.readline().split(', ')
        keys = [key.strip() for key in keys]
        for line in file:
            record = {}
            for i, item in enumerate(line.split(', ')):
                record[keys[i]] = item.strip()
            records.append(record)
    return records


with open('input.bin', 'wb') as file:
    records = open_txt_recs('records.txt')
    for record in records:
        for key, value in record.items():
            file.write('{}: {}, '.format(key, value).encode('UTF-8'))
        file.write('\n'.encode('UTF-8'))


matrix = [[1, 2, 3],
          [12.9, 129, 123],
          [921, 127, 12]]

e = len(str(max([matrix[i] for i in range(len(matrix) * len(matrix[0]))], key=lambda x: str(x))))

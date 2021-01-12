def get_records():
    records = []
    keys = ['Наименование модели', 'Цена в долларах США', 'Масса ноутбука', 'Габариты ноутбука', 'Частота процессора',
            'Макс. объём ОЗУ', 'Размер диагонали', 'Размер видеопамяти', 'Разрешение дисплея', 'Частота дисплея',
            'Объём HDD']
    with open('input.txt') as file:
        for line in file:
            new_record = {keys[0]: line[:19],
                          keys[1]: line[19:23],
                          keys[2]: line[24:27],
                          keys[3]: line[28:42],
                          keys[4]: line[42:46],
                          keys[5]: line[47:50],
                          keys[6]: line[51:55],
                          keys[7]: line[56],
                          keys[8]: line[58:67],
                          keys[9]: line[68:70],
                          keys[10]: line[71:76]}
            records.append(new_record)
    return records


def task(records):
    new_records = []
    for record in records:
        try:
            if float(record[list(record.keys())[-1]]) >= 1:
                new_records.append(record)
        except:
            pass
    new_records.sort(key=lambda record: int(record[list(record.keys())[4]]))
    return new_records



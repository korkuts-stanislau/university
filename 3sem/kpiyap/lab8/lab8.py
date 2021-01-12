def get_records():
    records = []
    with open('input.txt') as file:
        keys = file.readline().strip().split(', ')
        for line in file:
            record = dict()
            for key, value in zip(keys, line.strip().split(', ')):
                record[key] = value
            records.append(record)
    return records


def output_records(records):
    result = ''
    result += 'Num|{:10}|{:20}|{:14}|{:30}|{:30}|{:16}|{:20}\n'.format(*records[0].keys())
    for i, record in enumerate(records):
        result += '{:>3}|{:10}|{:20}|{:>14}|{:30}|{:30}|{:>16}|{:20}\n'.format(i + 1, *record.values())
    return result


def input_new_record(records):
    new_record = {}
    for key in records[0].keys():
        new_record[key] = input('Введите {}\n'.format(key))
    records.append(new_record)
    return records


def del_record_with_number(records, num):
    del records[num - 1]
    return records


def del_record_in_given_date(records, date):
    new_records = []
    for record in records:
        if record['Дата'] != date:
            new_records.append(record)
    return new_records


def change_patient_diagnosis(records, fio, new_diagnosis):
    for i in range(len(records)):
        if records[i]['ФИО больного'] == fio:
            records[i]['Диагноз больного'] = new_diagnosis
    return records


def output_patient_records(records, fio):
    result = []
    for record in records:
        if record['ФИО больного'] == fio:
            result += '{:10}|{:20}|{:>14}|{:30}|{:30}|{:>16}|{:20}\n'.format(*record.values())
    return result

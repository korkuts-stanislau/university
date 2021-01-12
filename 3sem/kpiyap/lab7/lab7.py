def task1(string):
    return 'Input string "{}"\nOutput string "{}"\n' \
           '"BC" pairs count = {}, "DE" pairs count = {}'.format(
            string, string.replace(',A', ','), string.count('BC'), string.count('DE'))


def task2(string):
    words = string.split()
    count = 0
    for word in words:
        if 'П' in word:
            count += 1
    return 'Input string "{}"\nWords\' with "П" count is equal to {}'.format(string, count)


def task3(string):
    words = string.split()
    rev_words = []
    for word in words:
        if word == word[-1:: -1]:
            rev_words.append(word)
    return 'Input string "{}"\nChangeling words: {}'.format(string, rev_words)


def task4(string):
    alpha_dict = dict()
    for let in string:
        if let.isalpha():
            if let.upper() in alpha_dict:
                alpha_dict[let.upper()] += 1
            else:
                alpha_dict[let.upper()] = 1
    count_dict = dict()
    for key, value in alpha_dict.items():
        if value in count_dict:
            count_dict[value].append(key)
        else:
            count_dict[value] = [key]
    return 'Input string "{}"\nThe most common letters: {}'.format(string, sorted(count_dict[max(count_dict.keys())]))


def find_max_len_words(string):
    words = string.split()
    words.sort(key=lambda word: len(word))
    return sorted([word for word in words if len(word) == len(words[-1])])


def task5(string):
    return 'Input string "{}"\n' \
           'The biggest word "{}"'.format(string, find_max_len_words(string)[0])


def task6(string, a):
    max_words = ' '.join(find_max_len_words(string))
    return 'Input string "{}"\n' \
           'The letter {} occurs {} times in words of maximum length'.format(string, a, max_words.count(a))


task7 = task5


def task8(string, first_word):
    count = len(first_word)
    word = first_word
    while count < len(string):
        new_word = ''
        for let in word:
            if let == 'A':
                new_word += 'BAB'
            else:
                new_word += 'A'
        count += len(new_word)
        word = new_word
    return 'Input string "{}"\n' \
           'The last word of string "{}"'.format(string, word)

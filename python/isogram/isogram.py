def is_isogram(string):
    a = list(filter(lambda x: x.isalpha(), string.lower()))
    return len(set(a)) == len(a)

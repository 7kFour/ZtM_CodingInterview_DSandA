array1 = ['a', 'b', 'c', 'x']
array2 = ['z', 'y', 'i']

array3 = ['a', 'b', 'c', 'x']
array4 = ['z', 'y', 'x']

# naive approach
# O(a*b) -- O(n^2) if the lists are the same length


def contains_common(arr1, arr2):
    for i in arr1:
        for j in arr2:
            if i == j:
                return True

    return False


# false
print(contains_common(array1, array2))

# true
print(contains_common(array3, array4))

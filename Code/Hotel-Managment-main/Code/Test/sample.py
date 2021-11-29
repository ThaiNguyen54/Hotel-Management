import pytest


def calculate_sum(xs):
    """Compute sum of an array

    Args:
        xs (list): array that need to compute

    Returns:
        float: sum of xs
    """
    result = 0
    for x in xs:
        result += x
    return result


def find_divisor(x):
    """Find all divisor of an integer

    Args:
        x (int)

    Returns:
        list: list of divisor
    """
    divisors = []
    for i in range(1, x):
        if x % i == 0:
            divisors.append(i)
    return divisors


def check_perfect_number(x):
    """Check if a integer is perfect number. 
    Ex: 6 is a perfect number because its divisors is 1,2,3 and
    1 + 2 + 3 = 6

    Args:
        x (integer): the integer that need to check

    Returns:
        boolean: Checked result
    """
    if calculate_sum(find_divisor(x)) == x:
        return True
    return False

# # Unit test
# def test_calculate_sum():
#     assert calculate_sum([1,2,6,7]) == 6
# def test_find_divisor():
#     assert find_divisor(10) == [1,2,5]

# # Integration test
# def test_check_perfect_number():
#     assert check_perfect_number(6) == True


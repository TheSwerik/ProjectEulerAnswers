def solve(limit=4000000):
    a,  c = 1,  0
    b = 2
    while b < limit:
        if b % 2 == 0:
            c += b
        helper = b
        b += a
        a = helper
    print(c)


if __name__ == "__main__":
    solve()

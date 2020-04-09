def solve(limit=1000):
    x = 0
    for i in range(limit):
        if i % 3 == 0 or i % 5 == 0:
            x += i
    print(x)


if __name__ == "__main__":
    solve()

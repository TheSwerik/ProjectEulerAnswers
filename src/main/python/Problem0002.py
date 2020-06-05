import time


def solve(limit=4000000):
    start_time = time.time()
    a, b, c = 1, 2, 0
    while b < limit:
        if b % 2 == 0:
            c += b
        helper = b
        b += a
        a = helper
    print("Result:\t" + str(c) + "\tTime:\t" + str((time.time() - start_time) * 1000) + "ms")


if __name__ == "__main__":
    solve()

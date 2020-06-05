import time


def solve(limit=1):
    start_time = time.time()
    result = 1
    print("Result:\t" + str(result) + "\tTime:\t" + str((time.time() - start_time) * 1000) + "ms")


if __name__ == "__main__":
    solve()

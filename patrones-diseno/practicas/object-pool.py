class ReusablePool:
    def __init__(self, size):
        self._reusables = [Reusable() for _ in range(size)]

    def acquire(self):
        return self._reusables.pop()

    def release(self, reusable):
        self._reusables.append(reusable)


class Reusable:
    pass


def main():
    reusable_pool = ReusablePool(10)

    print("Number of objects: {0}".format(len(reusable_pool._reusables)))

    for number in range(len(reusable_pool._reusables)):
        reusable = reusable_pool.acquire()
        print("{0}: {1}".format(number,reusable))

    print("Number of objects: {0}".format(len(reusable_pool._reusables)))

    


if __name__ == "__main__":
    main()
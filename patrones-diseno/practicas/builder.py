from enum import Enum

class Dough(Enum):
    WHITE = 1
    BROWN = 2

class Cheese(Enum):
    AMERICAN = 1
    ITALIAN = 2

class Toppings(Enum):
    PINEAPPLE = 1
    JAM = 2
    PEPPERS = 3
    ONION = 4
    CHILE = 5
    CHORIZO = 6

# class pizza
class Pizza:
    def __init__(self, __dough, __cheese, __toppings):
        self.__dough = __dough
        self.__cheese = __cheese
        self.__toppings = __toppings

    def returnPizza(self):
        print("Dough: %s" % (self.__dough ))
        print("Cheese: %s" % (self.__cheese))
        print("Toppings: ")
        for topping in self.__toppings:
            print("\t%s" % (topping))


class PizzaBuilder:
    __dough = ""
    __cheese = ""
    __toppings = set()

    def setDough(self, __dough):
        self.__dough = __dough
    
    def setCheese(self, __cheese):
        self.__cheese = __cheese
    
    def setTopping(self, __topping):
        self.__toppings.add(__topping)

    def buildPizza(self):
        return Pizza(self.__dough, self.__cheese, self.__toppings)

if __name__ == "__main__":
    # HAWAIANA
    print("HAWAIANA")
    pizza_builder = PizzaBuilder()
    pizza_builder.setDough(Dough.WHITE.name)
    pizza_builder.setCheese(Cheese.ITALIAN.name)
    pizza_builder.setTopping(Toppings.PINEAPPLE.name)
    pizza_builder.setTopping(Toppings.JAM.name)
    pizza = pizza_builder.buildPizza()
    pizza.returnPizza()

    # MEXICANA
    print("MEXICANA")
    pizza_builder = PizzaBuilder()
    pizza_builder.setDough(Dough.WHITE.name)
    pizza_builder.setCheese(Cheese.ITALIAN.name)
    pizza_builder.setTopping(Toppings.ONION.name)
    pizza_builder.setTopping(Toppings.PEPPERS.name)
    pizza_builder.setTopping(Toppings.CHILE.name)
    pizza_builder.setTopping(Toppings.CHORIZO.name)

    pizza = pizza_builder.buildPizza()
    pizza.returnPizza()
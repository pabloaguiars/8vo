# builder_practice = __import__('builder') # we use previous builder.py file

class Singleton(type):
    _instances = {}
    def __call__(cls, *args, **kwargs):
        if cls not in cls._instances:
            cls._instances[cls] = super(Singleton, cls).__call__(*args, **kwargs)
        return cls._instances[cls]

''''
clase que implementa singleton, 
para eliminar el singleton, 
quitar metaclass=Singleton
'''
class Pizza(metaclass=Singleton):
    name = ""

    def getName(self):
        return self.name

    def setName(self, name):
        self.name = name

if __name__ == "__main__":
    pizza1 = Pizza()
    pizza1.setName("Mexicana")

    pizza2 = Pizza()
    pizza2.setName("Hawaina")

    pizza3 = Pizza()
    pizza3.setName("Mixta")

    print(pizza1.getName())
    print(pizza2.getName())
    print(pizza3.getName())

# class PizzaService():
#     __pizza_builder = None

#     def __init__(self):
#         self.__pizza_builder = builder_practice.PizzaBuilder()

#     def pizza_mexicana(self):
#         self.__pizza_builder.setDough(builder_practice.Dough.WHITE.name)
#         self.__pizza_builder.setCheese(builder_practice.Cheese.ITALIAN.name)
#         self.__pizza_builder.setTopping(builder_practice.Toppings.PEPPERS.name)
#         self.__pizza_builder.setTopping(builder_practice.Toppings.CHILE.name)
#         self.__pizza_builder.setTopping(builder_practice.Toppings.ONION.name)
#         self.__pizza_builder.setTopping(builder_practice.Toppings.CHORIZO.name)
#         pizza = self.__pizza_builder.buildPizza()
#         return pizza

#     def pizza_hawaiana(self):
#         self.__pizza_builder.setDough(builder_practice.Dough.WHITE.name)
#         self.__pizza_builder.setCheese(builder_practice.Cheese.ITALIAN.name)
#         self.__pizza_builder.setTopping(builder_practice.Toppings.PINEAPPLE.name)
#         self.__pizza_builder.setTopping(builder_practice.Toppings.JAM.name)
#         pizza = self.__pizza_builder.buildPizza()
#         return pizza

#     def pizza_mixta(self):
#         self.__pizza_builder.setDough(builder_practice.Dough.WHITE.name)
#         self.__pizza_builder.setCheese(builder_practice.Cheese.ITALIAN.name)
#         self.__pizza_builder.setTopping(builder_practice.Toppings.PEPPERS.name)
#         self.__pizza_builder.setTopping(builder_practice.Toppings.CHILE.name)
#         self.__pizza_builder.setTopping(builder_practice.Toppings.ONION.name)
#         self.__pizza_builder.setTopping(builder_practice.Toppings.CHORIZO.name)
#         self.__pizza_builder.setTopping(builder_practice.Toppings.PINEAPPLE.name)
#         self.__pizza_builder.setTopping(builder_practice.Toppings.JAM.name)
#         pizza = self.__pizza_builder.buildPizza()
#         return pizza

# if __name__ == "__main__":
#     pizza_service = PizzaService()
#     hawaina = pizza_service.pizza_hawaiana()
#     mexicana = pizza_service.pizza_mexicana()
#     mixta = pizza_service.pizza_mixta()
    
#     hawaina.returnPizza()
#     mexicana.returnPizza()
#     mixta.returnPizza()

# abstract class
class IceCream():
    def Sabor(self):
        pass

# strawberry ice cream
class Strawberry(IceCream):
    def Sabor(self):
        return "Strawberry"

# vainilla ice cream
class Vainilla(IceCream):
    def Sabor(self):
        return "Vainilla"

# chocolate ice cream
class Chocolate(IceCream):
    def Sabor(self):
        return "Chocolate"

# factory
class IceCreamFactory():
    def CreateIceCream(self):
        pass

# strawberry factory
class StrawberryFactory(IceCreamFactory):
    def CreateIceCream(self):
        return Strawberry()

# vainilla factory
class VainillaFactory(IceCreamFactory):
    def CreateIceCream(self):
        return Vainilla()

# chocolate factory
class ChocolateFactory(IceCreamFactory):
    def CreateIceCream(self):
        return Chocolate()

# client
if __name__ == "__main__":
    strawberry_icecream = StrawberryFactory().CreateIceCream()
    vainilla_icecream = VainillaFactory().CreateIceCream()
    chocolate_icecream = ChocolateFactory().CreateIceCream()

    print(strawberry_icecream.Sabor())
    print(vainilla_icecream.Sabor())
    print(chocolate_icecream.Sabor())
import copy

class Interior():
    __banios_completos = 0
    __banios_medios = 0
    __habitaciones = 0
    __cuartos_de_lavado = 0

    def set_banios_completos(self, banios_completos):
        self.__banios_completos = banios_completos
    
    def get_banios_completos(self):
        return self.__banios_completos

    def set_banios_medios(self, banios_medios):
        self.__banios_medios= banios_medios
    
    def get_banios_medios(self):
        return self.__banios_medios

    def set_habitaciones(self, habitaciones):
        self.__habitaciones = habitaciones
    
    def get_habitaciones(self):
        return self.__habitaciones

    def set_cuartos_de_lavado(self, cuarto_de_lavado):
        self.__cuartos_de_lavado = cuarto_de_lavado
    
    def get_cuartos_de_lavado(self):
        return self.__cuartos_de_lavado

class Exterior():
    __cocheras = 0
    __patios = 0
    __jardines = 0

    def set_cocheras(self, cocheras):
        self.__cocheras = cocheras
    
    def get_cocheras(self):
        return self.__cocheras

    def set_patios(self, patios):
        self.__patios = patios
    
    def get_patios(self):
        return self.__patios

    def set_jardines(self, jardines):
        self.__jardines = jardines
    
    def get_jardines(self):
        return self.__jardines

class Vivienda():
    __id = 0
    __cuartos = 0
    __pisos = 0

    __interior = None
    __exterior = None

    def __init__(self, id = 0, cuartos = 0, pisos = 0, interior = Interior(), exterior = Exterior()):
        self.__id = id
        self.__cuartos = cuartos
        self.__pisos = pisos
        self.__interior = interior
        self.__exterior = exterior
    
    def set_id(self, id):
        self.__id = id
    
    def get_id(self):
        return self.__id

    def set_cuartos(self, cuartos):
        self.__cuartos = cuartos
    
    def get_cuartos(self):
        return self.__cuartos

    def set_pisos(self, pisos):
        self.__pisos = pisos
    
    def get_pisos(self):
        return self.__pisos
    
    def set_interior(self, interior):
        self.__interior = interior
    
    def get_interior(self):
        return self.__interior

    def set_exterior(self, exterior):
        self.__exterior = exterior
    
    def get_exterior(self):
        return self.__exterior

    def __str__(self):
        return "\nIdentificador:{9}\nCuartos: {0}\nPisos: {1}\nBaños completos: {2}\nBaños medios: {3}\nHabitaciones: {4}\nCuartos de lavado: {5}\nCocheras: {6}\nPatios: {7}\nJardines: {8}".format(self.get_cuartos() ,self.get_pisos() , self.__interior.get_banios_completos(), self.__interior.get_banios_medios(), self.__interior.get_habitaciones(), self.__interior.get_cuartos_de_lavado(), self.__exterior.get_cocheras(), self.__exterior.get_patios(), self.__exterior.get_jardines(),self.get_id())

    def __copy__(self):
        new = self.__class__(self.get_id() ,self.get_cuartos(), self.get_pisos())
        new.__dict__.update(self.__dict__)

        new.set_interior(copy.copy(self.get_interior()))
        new.set_exterior(copy.copy(self.get_exterior()))
        return new
    
    def __deepcopy__(self, memo={}):
        new = self.__class__(self.get_id() ,self.get_cuartos(), self.get_pisos())
        new.__dict__.update(self.__dict__)

        new.set_interior(copy.deepcopy(self.get_interior(), memo))
        new.set_exterior(copy.deepcopy(self.get_exterior(), memo))
        return new

if __name__ == "__main__":
    interior = Interior()
    exterior = Exterior()
    vivienda = Vivienda(1,0,0)
    vivienda.set_cuartos(5)
    vivienda.get_interior().set_habitaciones(3)
    
    print(vivienda)

    # vivienda_copy = vivienda.__copy__()
    # vivienda_copy.set_id(2)
    # vivienda_copy.set_cuartos(4)
    # vivienda_copy.get_interior().set_habitaciones(4)
    
    # print(vivienda)
    # print(vivienda_copy)

    vivienda_deepcopy = vivienda.__deepcopy__()
    vivienda_deepcopy.set_id(2)
    vivienda_deepcopy.set_cuartos(4)
    vivienda_deepcopy.get_interior().set_habitaciones(4)
    
    print(vivienda)
    print(vivienda_deepcopy)

    
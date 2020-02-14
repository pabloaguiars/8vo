# abstract products
class Letter:
   __documents_family = ""
   __document_type = ""

   def __init__(self, __documents_family):
      self.__documents_family = __documents_family
      self.__document_type = "letter"
   
   def getDocumentFamily(self):
      return self.__documents_family
   
   def getDocumentType(self):
      return self.__document_type

class Resume:
   __documents_family = ""
   __document_type = ""

   def __init__(self, __documents_family):
      self.__documents_family = __documents_family
      self.__document_type = "resume"
   
   def getDocumentFamily(self):
      return self.__documents_family
   
   def getDocumentType(self):
      return self.__document_type

# concrete products
class FancyLetter(Letter):
   def __init__(self):
      Letter.__init__(self, "Fancy")

class ModernLetter(Letter):
   def __init__(self):
      Letter.__init__(self, "Modern")

class FancyResume(Resume):
   def __init__(self):
      Resume.__init__(self, "Fancy")

class ModernResume(Resume):
   def __init__(self):
      Resume.__init__(self, "Modern")

# abstract factory class
class DocumentCreator:
   def createLetter(self): 
      pass
   def createResume(self): 
      pass

# concrete factories
class FancyDocumentCreator(DocumentCreator):
   def createLetter(self):
      return FancyLetter()
   def createResume(self):
      return FancyResume()

class MordernDocumentCreator(DocumentCreator):
   def createLetter(self):
      return ModernLetter()
   def createResume(self):
      return ModernResume()

if __name__ == "__main__":
   fancy = True
   modern = not fancy
   
   if fancy:
      document_creator = FancyDocumentCreator()
   elif modern:
      document_creator = MordernDocumentCreator()
   
   letter = document_creator.createLetter()
   resume = document_creator.createResume()
   
   print ("%s:%s" % (letter.getDocumentFamily() , letter.getDocumentType()))
   print ("%s:%s" % (resume.getDocumentFamily() , resume.getDocumentType()))

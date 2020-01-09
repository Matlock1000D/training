
#Testikoodia pyyttonilla kikkailuun

class ParasLuokka:
    def __init__(self, nimi, ikä):
        self.nimi = nimi
        self.ikä = ikä

    def declare(self):
        print("Hei, olen " + self.nimi)

p1 = ParasLuokka("Juhani",36)

p1.declare()

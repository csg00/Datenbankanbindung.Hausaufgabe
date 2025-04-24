import mariadb
import tkinter as tk
from tkinter import ttk, messagebox

 
import mariadb
import sys
 
 
class Artikel:
   def __init__(self, artikel, bestand, lieferant):
      self.name = artikel
      self.bestand = bestand
      self.lieferant = lieferant
 

 
#connect mariadb
 
try:
    conn = mariadb.connect(
        user = "Goetz",
        password = "Starwars@00",
        host = "localhost",
        port = 3306,
        database = "schlumpfshop3")
 
except mariadb.Error as e:
   print(f"Error connecting to MariaDB PLatform: {e}")
   sys.exit(1)
cur = conn.cursor()
 
cur.execute( """SELECT artikel.Artikelname, artikel.Lagerbestand, lieferant.Lieferantenname
 
FROM artikel inner JOIN lieferant
    ON `artikel`.`Lieferant` = `lieferant`.`ID_Lieferant`""")
 
#min = int(input("Geben Sie den Mindestbestand ein: "))
 
artikel_liste = []
 
for a, b, c in cur:
    werte = Artikel(a, b, c)
    artikel_liste.append(werte)
 
# for item in artikel_liste:
#    if min >= item.bestand:
     
#     print(f"{item.name}, {item.bestand}, {item.lieferant}")

def anzeigen():
    try:
        min_bestand = int(entry.get())
    except ValueError:
        messagebox.showwarning("Ungültige Eingabe", "Bitte eine ganze Zahl eingeben.")
        return

    for row in tree.get_children():
        tree.delete(row)

    for item in artikel_liste:
        if min_bestand >= item.bestand:
            tree.insert("", "end", values=(item.name, item.bestand, item.lieferant))
            #print(f"{item.name}, {item.bestand}, {item.lieferant}")

root = tk.Tk()
root.title("Artikel unter dem Mindestbestand")
root.geometry("600x400")


frame = ttk.Frame(root, padding=10)
frame.pack(fill="x")


ttk.Label(frame, text="Mindestbestand:").pack(side="left")
entry = ttk.Entry(frame, width=10)
entry.pack(side="left", padx=5)


ttk.Button(frame, text="Anzeigen", command=anzeigen).pack(side="left", padx=5)




columns = ("Artikel", "Bestand", "Lieferant")
tree = ttk.Treeview(root, columns=columns, show="headings")
for col in columns:
    tree.heading(col, text=col)
    tree.column(col, width=150)
tree.pack(expand=True, fill="both", padx=10, pady=10)

root.mainloop()
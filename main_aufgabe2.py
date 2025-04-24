import mariadb
import tkinter as tk
from tkinter import ttk
import sys


class Anrede:
    def __init__(self, id, bezeichnung):
        self.id = id
        self.bezeichnung = bezeichnung



anrede_liste = []


try:
    conn = mariadb.connect(
        user="Goetz",
        password="Starwars@00",
        host="localhost",
        port=3306,
        database="schlumpfshop3"
    )
except mariadb.Error as e:
    print(f"Error connecting to MariaDB Platform: {e}")
    sys.exit(1)


cur = conn.cursor()


def neue_anrede_einfuegen():
    anrede_text = eingabe.get().strip()
    if anrede_text == "":
        return
    try:
        
        cur.execute(f"INSERT INTO `anrede`(Anrede) VALUES ('{anrede_text}')")
        conn.commit()  
        neue_id = cur.lastrowid  
        neue_anrede = Anrede(neue_id, anrede_text)  
        anrede_liste.append(neue_anrede)  
        tree.insert("", "end", values=(neue_anrede.id, neue_anrede.bezeichnung))  
        eingabe.delete(0, tk.END)  
    except mariadb.Error as e:
        print(f"Fehler beim Einfügen: {e}")


cur.execute(f"SELECT `ID_Anrede`, `Anrede` FROM `anrede`")  
for id, bez in cur:
    anrede = Anrede(id, bez)
    anrede_liste.append(anrede)


root = tk.Tk()
root.title("Neue Anrede hinzufügen")


frame = ttk.Frame(root, padding=10)
frame.pack(fill="x")


ttk.Label(frame, text="Anrede:").pack(side="left")
eingabe = ttk.Entry(frame, width=20)
eingabe.pack(side="left", padx=5)


ttk.Button(frame, text="Hinzufügen", command=neue_anrede_einfuegen).pack(side="left")


columns = ("ID", "Bezeichnung")
tree = ttk.Treeview(root, columns=columns, show="headings")
for col in columns:
    tree.heading(col, text=col)
tree.pack(expand=True, fill="both", padx=10, pady=10)


for eintrag in anrede_liste:
    tree.insert("", "end", values=(eintrag.id, eintrag.bezeichnung))

root.mainloop()

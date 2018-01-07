from shutil import copyfile
import os
import tkinter
from tkinter import filedialog
def GetDirItems(directory):
	print("s")
def Copfile(src):
	print(src)
	print (os.path.basename(src))
def InstanceFile():
	B = tkinter.filedialog.askopenfilename()
	return B
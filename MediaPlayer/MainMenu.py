import tkinter
from GetFiles import InstanceFile
import os
from SoundFuncs import PlaySound, StopSound

# played = 0
# def ItemSelected(item,List):
	# if(len(item)>0):
		# print(item[0])
# def GetButton():
	# played = 1
# ###main
# def MainMenu:
	# top = tkinter.Tk()
	# ####Build Widgets here
	# Play = tkinter.Button(top,text="Play",command=GetButton)
	# played = Play.invoke()
	# Load = tkinter.Button(top,text="Load Song")
	# Clear = tkinter.Button(top,text = "Clear Song List")
	# List = tkinter.Listbox(top,selectmode = 'single')
	# List.insert(1,"Hi")
	# List.insert(2,"There")
	# if(played == 1):
		# what = List.curselection()
		# ItemSelected(what,List)
		# played = 0
	# List.pack()
	# Play.pack()
	# Load.pack()
	# Clear.pack()
	# ####End Widgets
	# top.mainloop()
	# print(played)
	# ###endmain
class Apps(tkinter.Frame):
	Playclicked = 0
	Itemindex = 1
	dir
	list
	songlist=[]
	currsong=None
	def PlaySong(self):
		if len(self.list.curselection())>0:
			src = self.list.curselection()[0]
			src = self.songlist[src]
			self.currsong = PlaySound(src)
	def Load(self):
		print("pressed")
		BN = InstanceFile()
		self.songlist.append(BN)
		self.list.insert(tkinter.END,os.path.basename(BN))
		print("done")
		self.Itemindex +=1
	def Delete(self):
		if len(self.list.curselection())>0:
			listselect = self.list.curselection()
			del self.songlist[listselect[0]]
			self.list.delete(listselect[0])
			print (self.songlist)
	def StopSong(self):
		StopSound(self.currsong)
	def __init__(self,TeeKay):
		butt = tkinter.Button(TeeKay,text = "Play",command = self.PlaySong)
		butt2 = tkinter.Button(TeeKay,text = "Load",command = self.Load)
		butt3 = tkinter.Button(TeeKay,text = "Delete",command = self.Delete)
		butt4 = tkinter.Button(TeeKay,text = "Stop",command = self.StopSong)
		self.list = tkinter.Listbox(TeeKay,selectmod = 'single')
		self.list.pack()
		butt.pack()
		butt4.pack()
		butt2.pack()
		butt3.pack()

top = tkinter.Tk()
sap = Apps(top)

top.mainloop()
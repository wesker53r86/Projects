#import pyaudio,wave,sys
import winsound
import vlc
#import pygame

def PlaySound(src):
	print(src)
	p = vlc.MediaPlayer(src)
	p.play()
	return p
def StopSound(src):
	src.stop()
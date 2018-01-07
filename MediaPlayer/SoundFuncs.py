#import pyaudio,wave,sys
import winsound
import pygame

def PlaySound(src):
	winsound.PlaySound(str(src),winsound.SND_FILENAME)
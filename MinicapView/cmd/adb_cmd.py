import os
import sys

def exe(cmd):
	print cmd
	os.system(cmd)
	
mydir = "/data/local/tmp"
if False:
	exe("adb push  minicap.so " + mydir)	
	exe("adb push minicap "+mydir)
	exe("adb shell chmod 777 "+ mydir+"/minicap")
exe("adb forward tcp:1313 localabstract:minicap")
exe("adb shell LD_LIBRARY_PATH="+mydir+" "+mydir+"/minicap "+"-P 1280x720@640x360/0")
raw_input("input any keys")
# remote-ctrl

port 1384

## setup service

1. publish
2. setup service 

sc CREATE RemoteCtrl binPath="C:\Users\user\source\repos\remote-ctrl\remote-ctrl\bin\Release\net8.0-windows10.0.17763.0\win-x64\remote-ctrl.exe"
sc START RemoteCtrl

remove it

sc DELETE RemoteCtrl

## sources

http://www.kbdedit.com/manual/low_level_vk_list.html
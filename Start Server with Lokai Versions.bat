@echo off
title ServUO - Powered by Lokai!

SET Parameters=
SET Debug=
SET Service=
SET S1=      
SET S2=                            

:MainMenu
CLS
SET choice=
echo.
echo  ษอออออออออออออออออออออออออออออออออออออหอออออออออออออออออป
echo  บ ฎออฏ Lokai Versions Batch File ฎออฏ บ                 บ
echo  ฬอออออออออออออออออออออออออออออออออออออน                 บ
echo  บ v1.0        Main Menu               บ                 บ
echo  ฬอออออออออออออออออออออออออออออออออออออน                 บ
echo  บ                                     บ     \    /      บ
echo  บ d) Debug Mode                       บ     )\~~/(      บ
echo  บ                                     บ     ณ(oO)ณ      บ
echo  บ s) Service Mode (logs Console msgs) บ      \ณณ/       บ
echo  บ                                     บ      (OO)       บ
echo  บ z) Versions Menu                    บ+--vVv------vVv-+บ
echo  บ                                     บฐฐฐฒฒฒฐฐฐฒฒฒฐฐฐฒฒบ
echo  บ r) **** Run Server Now ****         บฒฒฐฐฐฒฒฒฐฐฐฒฒฒฐฐฐบ
echo  บ                                     บฐฒฒฒฐฐฐฒฒฒฐฐฐฒฒฒฐบ
echo  ฬอออออออออออออออออออออออออออออออออออออสอออออออออออออออออน
echo  บ PARAMETERS:                                           บ
echo  บ                                                       บ
echo  บ Options: %Service%%Debug%%S1% Versions: %Parameters%%S2%บ
echo  บ                                                       บ
echo  ศอออออออออออออออออออออออออออออออออออออออออออออออออออออออผ

SET /P choice= Choose an option: 

if '%choice%'=='d' GOTO DEBUG
if '%choice%'=='s' GOTO SERVICE
if '%choice%'=='z' GOTO VMenu
if '%choice%'=='r' GOTO END

GOTO MainMenu

:DEBUG
if "%Debug%"==" -d" GOTO UNDEBUG
SET Debug= -d
SET S1=   
if "%Service%"=="" GOTO MainMenu
SET S1=
GOTO MainMenu

:SERVICE
if "%Service%"==" -s" GOTO UNSERVICE
SET Service= -s
SET S1=   
if "%Debug%"=="" GOTO MainMenu
SET S1=
GOTO MainMenu

:UNDEBUG
SET Debug=
SET S1=      
if "%Service%"=="" GOTO MainMenu
SET S1=   
GOTO MainMenu

:UNSERVICE
SET Service=
SET S1=      
if "%Debug%"=="" GOTO MainMenu
SET S1=   
GOTO MainMenu


GOTO END

:VMenu
CLS
echo.
echo  ษอออออออออออออออออออออออออออออออออออออหอออออออออออออออออป
echo  บ ฎออฏ Lokai Versions Batch File ฎออฏ บ                 บ
echo  ฬอออออออออออออออออออออออออออออออออออออน                 บ
echo  บ v1.0      Versions Menu             บ                 บ
echo  ฬอออออออออออออออออออออออออออออออออออออน                 บ
echo  บ                                     บ     \    /      บ
echo  บ 0) No Options   k) 1, 2 and 3       บ     )\~~/(      บ
echo  บ 1) 1 only       l) 1, 2 and 4       บ     ณ(oO)ณ      บ
echo  บ 2) 2 only       m) 1, 2 and 5       บ      \ณณ/       บ
echo  บ 3) 3 only       n) 1, 3 and 4       บ      (OO)       บ
echo  บ 4) 4 only       o) 1, 3 and 5       บ+--vVv------vVv-+บ
echo  บ 5) 5 only       p) 1, 4 and 5       บฐฐฐฒฒฒฐฐฐฒฒฒฐฐฐฒฒบ
echo  บ a) 1 and 2      q) 2, 3 and 4       บฒฒฐฐฐฒฒฒฐฐฐฒฒฒฐฐฐบ
echo  บ b) 1 and 3      r) 2, 3 and 5       บฐฒฒฒฐฐฐฒฒฒฐฐฐฒฒฒฐบ
echo  บ c) 1 and 4      s) 2, 4 and 5       บฐฐฐฒฒฒฐฐฐฒฒฒฐฐฐฒฒบ
echo  บ d) 1 and 5      t) 3, 4 and 5       บฒฒฐฐฐฒฒฒฐฐฐฒฒฒฐฐฐบ
echo  บ e) 2 and 3      u) 1, 2, 3 and 4    บฐฒฒฒฐฐฐฒฒฒฐฐฐฒฒฒฐบ
echo  บ f) 2 and 4      v) 1, 2, 4 and 5    บฐฐฐฒฒฒฐฐฐฒฒฒฐฐฐฒฒบ
echo  บ g) 2 and 5      w) 1, 3, 4 and 5    บฒฒฐฐฐฒฒฒฐฐฐฒฒฒฐฐฐบ
echo  บ h) 3 and 4      x) 2, 3, 4 and 5    บฐฒฒฒฐฐฐฒฒฒฐฐฐฒฒฒฐบ
echo  บ i) 3 and 5      y) 1, 2, 3, 4 and 5 บฐฐฐฒฒฒฐฐฐฒฒฒฐฐฐฒฒบ
echo  บ j) 4 and 5      z) MAIN MENU        บฒฒฐฐฐฒฒฒฐฐฐฒฒฒฐฐฐบ
echo  บ                                     บฐฒฒฒฐฐฐฒฒฒฐฐฐฒฒฒฐบ
echo  ศอออออออออออออออออออออออออออออออออออออสอออออออออออออออออน

SET /P option= Choose a menu option: 

if '%option%'=='z' GOTO MainMenu
if '%option%'=='0' SET Parameters=
if '%option%'=='1' SET Parameters= -LV1
if '%option%'=='2' SET Parameters= -LV2
if '%option%'=='3' SET Parameters= -LV3
if '%option%'=='4' SET Parameters= -LV4
if '%option%'=='5' SET Parameters= -LV5
if '%option%'=='a' SET Parameters= -LV1 -LV2
if '%option%'=='b' SET Parameters= -LV1 -LV3
if '%option%'=='c' SET Parameters= -LV1 -LV4
if '%option%'=='d' SET Parameters= -LV1 -LV5
if '%option%'=='e' SET Parameters= -LV2 -LV3
if '%option%'=='f' SET Parameters= -LV2 -LV4
if '%option%'=='g' SET Parameters= -LV2 -LV5
if '%option%'=='h' SET Parameters= -LV3 -LV4
if '%option%'=='i' SET Parameters= -LV3 -LV5
if '%option%'=='j' SET Parameters= -LV4 -LV5
if '%option%'=='k' SET Parameters= -LV1 -LV2 -LV3
if '%option%'=='l' SET Parameters= -LV1 -LV2 -LV4
if '%option%'=='m' SET Parameters= -LV1 -LV2 -LV5
if '%option%'=='n' SET Parameters= -LV1 -LV3 -LV4
if '%option%'=='o' SET Parameters= -LV1 -LV3 -LV5
if '%option%'=='p' SET Parameters= -LV1 -LV4 -LV5
if '%option%'=='q' SET Parameters= -LV2 -LV3 -LV4
if '%option%'=='r' SET Parameters= -LV2 -LV3 -LV5
if '%option%'=='s' SET Parameters= -LV2 -LV4 -LV5
if '%option%'=='t' SET Parameters= -LV3 -LV4 -LV5
if '%option%'=='u' SET Parameters= -LV1 -LV2 -LV3 -LV4
if '%option%'=='v' SET Parameters= -LV1 -LV2 -LV3 -LV5
if '%option%'=='w' SET Parameters= -LV1 -LV3 -LV4 -LV5
if '%option%'=='x' SET Parameters= -LV2 -LV3 -LV4 -LV5
if '%option%'=='y' SET Parameters= -LV1 -LV2 -LV3 -LV4 -LV5

if '%option%'=='0' SET S2=                            
if '%option%'=='1' SET S2=                       
if '%option%'=='2' SET S2=                       
if '%option%'=='3' SET S2=                       
if '%option%'=='4' SET S2=                       
if '%option%'=='5' SET S2=                       
if '%option%'=='a' SET S2=                  
if '%option%'=='b' SET S2=                  
if '%option%'=='c' SET S2=                  
if '%option%'=='d' SET S2=                  
if '%option%'=='e' SET S2=                  
if '%option%'=='f' SET S2=                  
if '%option%'=='g' SET S2=                  
if '%option%'=='h' SET S2=                  
if '%option%'=='i' SET S2=                  
if '%option%'=='j' SET S2=                  
if '%option%'=='k' SET S2=             
if '%option%'=='l' SET S2=             
if '%option%'=='m' SET S2=             
if '%option%'=='n' SET S2=             
if '%option%'=='o' SET S2=             
if '%option%'=='p' SET S2=             
if '%option%'=='q' SET S2=             
if '%option%'=='r' SET S2=             
if '%option%'=='s' SET S2=             
if '%option%'=='t' SET S2=             
if '%option%'=='u' SET S2=        
if '%option%'=='v' SET S2=        
if '%option%'=='w' SET S2=        
if '%option%'=='x' SET S2=        
if '%option%'=='y' SET S2=   

GOTO MainMenu

:END
SET Svc=
SET Dbg=
if "%Service%"==" -s" SET Svc= -service
if "%Debug%"==" -d" SET Dbg= -debug

ServUO.exe%Svc%%Dbg%%Parameters%

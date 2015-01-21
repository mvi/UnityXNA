@echo off

echo link Assets\Resources\Content from Platformer_4_0\Platformer\Content

mklink /D Assets\Resources\Content ..\..\Platformer_4_0\Platformer\Content
pause

 
echo link Assets\Scripts\XNAGame from Platformer_4_0\Platformer\Platformer

mklink /D Assets\Scripts\XNAGame ..\..\Platformer_4_0\Platformer\Platformer
pause

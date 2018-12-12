
// СОБЫТИЕ - если игрок зайдет
event_spleef_onconnect = [
	sendvar $arg1 i fog 300
	sendvar $arg1 i fogcolour 0x111111
	sendvar $arg1 f fogdomemax 1
	sendvar $arg1 f fogdomeheight 0
	sendvar $arg1 s skybox "socksky/emerald"
	//entupdate
	
	setweap $arg1 @spleef_spawn_weapon
	
]

delhandler onconnect event_spleef_onconnect
addhandler onconnect event_spleef_onconnect

spleef_speed = 1 // с какой скорость падают платформы
spleef_interval = 10 // какой интервал обновления будет

// СОБЫТИЕ - если игрок стрельнит
event_spleef_onshoot = [
	// if (<= (getpitch $arg1) 0) [ // прицел игрока должен быть внизу
		ent_index = (entnum (div (- $arg2 256) 32) (div (- $arg3 256) 32))
		if (=s (getalias (concatword "ent_" $ent_index)) "") [(concatword "ent_" $ent_index) = 0]
		if (= 0 $(concatword "ent_" $ent_index)) [
			if (= $spleef_anim 0) [
				entset @ent_index 0
			] [
				loop fall 2000 [
					asleep (* $spleef_interval $fall) [
						ent_index = (entnum (div (- @arg2 256) 32) (div (- @arg3 256) 32))
						if (= @fall 1999) [
							entset @ent_index 0
						] [
							entset @ent_index (at (entget @ent_index) 0) (at (entget @ent_index) 1) (at (entget @ent_index) 2) (-f $spleef_hight (*f $spleef_speed @@fall)) 0 (at (entget @ent_index) 5) (at (entget @ent_index) 6) (at (entget @ent_index) 7)
							(concatword "ent_" @ent_index) = 1
						]
					]
				]
			]
		]
	//]
]

delhandler onshoot event_spleef_onshoot
addhandler onshoot event_spleef_onshoot


// СОБЫТИЕ - следующего раунда
event_spleef_nextround = [
	asleep 1000 [
		say "^n^n^n^n^n"
		spleef_winner = ""
		loop l_win (listlen (bestfrag)) [spleef_winner = (concat $spleef_winner (getname (at (bestfrag) $l_win)))]
		say "^f1[@] ^f4Winners is^f2" (prettylist $spleef_winner)
	]
	asleep 10000 [exec "tmod/modes/spleef/spleef.cs"]
]

delhandler onimission event_spleef_nextround
addhandler onimission event_spleef_nextround


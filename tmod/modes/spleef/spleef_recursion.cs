
defaultvar spleef_regen 1 // сколько очков игрок получает каждую секунду
defaultvar spleef_lose 30 // сколько очков игрок теряет когда падает
// defaultvar spleef_indicator 0 // показывать ли индикатор здоровья

// addrec "spleef_indicator" 100 "spleef" [
	// if $spleef_indicator [
		// loop l_cn (- (listlen (players)) (listlen (botnum))) [
			// if (= -1 (entget (+ 256 (at (players) $l_cn)))) [
				// newent 5 (at (getpos (at (players) $l_cn)) 0) (at (getpos (at (players) $l_cn)) 1) (+ 20 (at (getpos (at (players) $l_cn)) 2)) 5 (gethealth (at (players) $l_cn)) 0x0f0
			// ] [
				// entset (+ 256 (at (players) $l_cn)) 5 (at (getpos (at (players) $l_cn)) 0) (at (getpos (at (players) $l_cn)) 1) (+ 10 (at (getpos (at (players) $l_cn)) 2)) 5 (gethealth (at (players) $l_cn)) 0x0f0
			// ]
		// ]
	// ]
// ]

addrec "spleef_death" 1000 "spleef" [
	if $spleef_enable [
		if (= (getmode) 2) [
			// спавн игроков
			loop cn $maxclients [
				if (= (getcn $cn) -1) [] [
					if (= (isspectator $cn) -1) [] [
						if (>= (at (getpos $cn) 2) 530) [
							if (<= (at (getpos $cn) 2) $spleef_hight_respawn) [ // при какой высоте оно будет респавнить
								if (= $spleef_messages 1) [if (= (getstate $cn) 0) [say (concatword "^f1" (getname $cn) " fell off")]]
								suicide $cn
							]
						] [
							list_ents = ""
							loop ent_spawn 256 [if (!= 0 (at (entget $ent_spawn) 5)) [list_ents = (concat $list_ents $ent_spawn)]] // сбор списка работающих ентити
							rnd_ent_spawn = (at $list_ents (rnd (listlen $list_ents))) // случайный выбор ентити
							setpos $cn (at (entget $rnd_ent_spawn) 1) (at (entget $rnd_ent_spawn) 2) $spleef_spawn
						]
					]
				]
			]
			
			// спавн бота
			loop cn_bot 4 [if (<= (at (getpos (+ 128 $cn_bot)) 2) $spleef_hight_respawn) [setpos (+ 128 $cn_bot) (at (entget $rnd_ent_spawn) 1) (at (entget $rnd_ent_spawn) 2) $spleef_spawn]]
				if (<= (listlen $list_ents) $spleef_minent) [ // если кол-во ентитов минимум, то будет перезапуск арены
				do $spleef_arena
				say "^f1[@] ^f4Arena was reloaded"
				
				list_ents = ""
				loop ent_spawn 256 [if (!= 0 (at (entget $ent_spawn) 5)) [list_ents = (concat $list_ents $ent_spawn)]] // сбор списка работающих ентити
			]
			
			// игрок получает +1 очко кажду секунду
			loop l_point (listlen (players)) [setfrags (at (players) $l_point) (max 0 (+ (getfrags (at (players) $l_point)) 1))]
			
		]
	]
]

// СОБЫТИЕ - когда игрок падает, он теряет 30 очков
addevent "ondeath" "spleef_lose" "spleef" [setfrags $arg1 (max 0 (- (getfrags $arg1) $spleef_lose))]
addevent "onsuicide" "spleef_lose" "spleef" [setfrags $arg1 (max 0 (- (getfrags $arg1) $spleef_lose))]

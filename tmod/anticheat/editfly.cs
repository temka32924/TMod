
cheat_wait = 50 // с каким интервалом давать сообщения об читерстве (5 сек)

if (=s (getalias cheat_msg) "") [cheat_msg = ""] // переменая сообщения об читерстве
if (=s (getalias cheat_msg) "") [cheat_msg_time = 0] // переменая сообщения об читерстве

// СОБЫТИЕ
rec_anticheat_editfly = []

asleep 100 [

	rec_anticheat_editfly = [
	
		loop cn_cheat $maxclients [
			if (= (getcn $cn_cheat) -1) [] [
				if (= (isediting $cn_cheat) 0) [
					if (= (getvar $cn_cheat "state") 0) [new_cheat_msg = (concat "^f3[CHEAT] ^f4Player^f2" (getname $cn_cheat) "^f4use fly but he not in edit mode")]
					if (= (getvar $cn_cheat "state") 8) [new_cheat_msg = (concat "^f3[CHEAT] ^f4Player^f2" (getname $cn_cheat) "^f4use fly but he not in edit mode")]
				]
			]
		]
		
		if (=s $new_cheat_msg $cheat_msg) [] [
			cheat_msg = $new_cheat_msg
			// sendtoadmin $new_cheat_msg
			cheat_msg_time = 0
		]
		
		cheat_msg_time = (+ $cheat_msg_time 1)
		
		if (= $cheat_msg_time $cheat_wait) [new_cheat_msg = ""] // когда стирать сообщение об нарушении
	
	
		asleep 100 [rec_anticheat_editfly]
	]
	
]


]

asleep 200 [rec_anticheat_editfly]
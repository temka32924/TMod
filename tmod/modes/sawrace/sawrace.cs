
// ОПЕРАТОР - диапазон, интервал
inter = [
	
	PlayerOne = $arg1
	PlayerTwo = $arg2
	
	interval = (- $PlayerOne $PlayerTwo)
	
	if (< $interval 0) [interval = (* $interval -1)] // если переменая оказывается отрицательной, он ее отзеркаливает (делает со знаком плюс)
	
	result $interval

]


sawrace_time = 0


// РЕКУРСИЯ //
rec_sawrace = []

asleep 120 [
	rec_sawrace = [
		
		sawrace_time = (+ $sawrace_time 1)
		
		loop i $finishes [

		zona_posX = (at (getfinish $i) 0)
		zona_posY = (at (getfinish $i) 1)
		zona_posZ = (at (getfinish $i) 2)

			loop zona_cn $maxclients [

				if (< (inter (at (getpos $zona_cn) 0) $zona_posX) 50) [ 
					if (< (inter (at (getpos $zona_cn) 1) $zona_posY) 50) [ 
						if (< (inter (at (getpos $zona_cn) 2) $zona_posZ) 50) [
							if (> $sawrace_time 100) [ // если времени набежало в 10 секунд, то будет показано сообщение
								say (divf $sawrace_time 10)
								sawrace_time = 0
							]
						]
					]
				]
				
			]
		]		
		
		
		asleep 100 [rec_sawrace]
	]
]

asleep 200 [rec_sawrace]

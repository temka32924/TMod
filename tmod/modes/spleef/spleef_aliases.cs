
entnum = [result (+ $arg1 (* $spleef_size $arg2))] // найти индекс (из сплифа)
delarena = [
	loop i 1000 [
		entset $i 0 // удаления
		(concatword "ent_" $i) = 0 // сброс соcтояния
	]
]

// обновление ентита (может это и не нужно)
entupdate = [loop z 1000 [entset $z (at (entget $z) 0) (at (entget $z) 1) (at (entget $z) 2) (at (entget $z) 3) (at (entget $z) 4) (at (entget $z) 5) (at (entget $z) 6) (at (entget $z) 7) (at (entget $z) 8)]]
allentunlock = [loop z 1000 [entunlock $z]]
enttree = [tree_list = "78 81 82 83 104 105 107 108";result (at $tree_list (rnd (listlen $tree_list)))]
flatarena = [delarena; loop x $spleef_size [ loop y $spleef_size [newent 2 (+ (+ 256 16) (* 32 $y)) (+ (+ 256 16) (* 32 $x)) $spleef_hight 0 (at $arg1 (rnd 1))] ] ]
// 151 (черно белые) 115 (с дырками железная) 116 (большая железная) 156 (деревяная платформа)
mixarena = [delarena; loop x $spleef_size [ loop y $spleef_size [newent 2 (+ (+ 256 16) (* 32 $y)) (+ (+ 256 16) (* 32 $x)) $spleef_hight 0 (at "151 115 116 156" (rnd 4))] ] ]
treearena = [
	delarena
	loop x $spleef_size [ loop y $spleef_size [newent 2 (+ (+ 256 16) (* 32 $y)) (+ (+ 256 16) (* 32 $x)) $spleef_hight 0 (at (concat "156 156 156 156 156 156 156" (enttree)) (rnd 8))] ] 
]


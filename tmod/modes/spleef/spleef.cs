
// НАСТРОЙКИ //
mapmode "spleef_test" 2
namemode = "spleef"
resetweapons
// setammo -1 2 999 // миниган
setammo -1 4 999 // винтовка
setammo -1 5 0 // бомба
setammo -1 6 999 // пистолет
setdamage -1 0 0
setdamage -1 1 0
setdamage -1 2 0
setdamage -1 3 0
setdamage -1 4 0
setdamage -1 5 0
setdamage -1 6 0

setpush -1 4 0 1000 // отдача винтовки

sendvar -1 i fog 300
sendvar -1 i fogcolour 0x111111
sendvar -1 f fogdomemax 1
sendvar -1 f fogdomeheight 0
sendvar -1 s skybox "socksky/emerald"

// ПЕРЕМЕНЫЕ //
spleef_enable = 1 // будет ли работать сплиф
spleef_size = 16 // размер арены N x N
spleef_time = 600 // 1 сек = 10, через сколько будет обновление карты
spleef_time_var = $spleef_time // дубликат
spleef_hight = 1000 // высота арены
spleef_hight_respawn = 900 // высота на которой будет респавн
spleef_spawn = 1000 // на какой вывоте спавнить игрока
spleef_minent = 128 // при каком минимальном кол-ве ентитов будет перезапускать арену
//spleef_arena = "flatarena 151" // какую арену спавнить (как вариант "treearena")
spleef_arena = "treearena" // какую арену спавнить (как вариант "treearena")
spleef_anim = 0 // делать ли анимацию падующих платформ и деревь
spleef_spawn_weapon = "2 1 0 999 0 999 0 0 999" // какое оружие спавнится
spleef_messages = 0 // оставлять ли сообщения об смертях игроков

// ЗАПУСК //
exec "tmod/modes/spleef/spleef_recursion.cs"
exec "tmod/modes/spleef/spleef_events.cs"
exec "tmod/modes/spleef/spleef_aliases.cs"

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

namespace Vocabulary
{
    public static class Words
    {
        public static string GetWord(Word word, SystemLanguage lang)
        {
            switch (lang)
            {
                case SystemLanguage.English:
                    switch (word)
                    {
                        case Word.ads: return "Ads";
                        case Word.brake: return "Brake";
                        case Word.buy: return "Buy";
                        case Word.capacity: return "Capacity";
                        case Word.cars: return "Cars";
                        case Word.continue_for: return "Continue for";
                        case Word.credits: return "Attribute list";
                        case Word.damage: return "Damage";
                        case Word.destroy: return "Destroy";
                        case Word.distance: return "Distance";
                        case Word.fire: return "Fire";
                        case Word.full: return "Full";
                        case Word.game_over: return "Game over";
                        case Word.health: return "Health";
                        case Word.music: return "Music";
                        case Word.pause: return "Pause";
                        case Word.play: return "Play";
                        case Word.quit: return "Quit";
                        case Word.select: return "Select";
                        case Word.selected: return "Selected";
                        case Word.settings: return "Settings";
                        case Word.sfx: return "Sfx";
                        case Word.shop: return "Shop";
                        case Word.special: return "Special";
                        case Word.tasks: return "Tasks";
                        case Word.total: return "Total";
                        case Word.credits_text: return
                                "Icon made by Vectors Market from www.flaticon.com\n3D: www.cgtrader.com\n\nCreators: NikitaLnc and DoraLnc";

                        case Word.switch_account: return "Switch Account";
                        case Word.disk: return "Disk";
                        case Word.cloud: return "Cloud";
                        case Word.best_distance: return "Best Distance";
                        case Word.last_visit: return "Last visit";
                        case Word.name: return "Name";
                        case Word.player_info: return "Player Info";
                        case Word.enter_your_name: return "Enter your name";
                        case Word.enter_new_name: return "Enter new name";
                        case Word.pay: return "Pay";
                        case Word.ok: return "Ok";
                        case Word.new_task_after: return "New task after";
                        case Word.collect_gems: return "Collect gems";
                        case Word.deal_damage: return "Deal damage";
                        case Word.kill_monsters: return "Kill monsters";
                        case Word.kill_zombies: return "Kill zombies";
                        case Word.reward: return "Reward";
                        case Word.privacy_policy: return "Privacy Policy";
                        case Word.network_require: return "Internet Required";
                        case Word.inventory: return "Inventory";

                        case Word.daily: return "Daily";
                        case Word.weekly: return "Weekly";
                        case Word.you_got: return "You Got";
                        case Word.promo_code: return "Promo Code";
                        case Word.the_promo_code_is_incorrect_or_used: return "The promo code is incorrect or used";
                        case Word.fuel: return "Fuel";


                        default:
                            throw new NotImplementedException("Word don't exist!");
                    }

                case SystemLanguage.Russian:
                    switch (word)
                    {
                        case Word.ads: return "Объявления";
                        case Word.brake: return "Тормоз";
                        case Word.buy: return "Купить";
                        case Word.capacity: return "Вместимость";
                        case Word.cars: return "Машины";
                        case Word.continue_for: return "Продолжить за";
                        case Word.credits: return "Список атрибутов";
                        case Word.damage: return "Урон";
                        case Word.destroy: return "Уничтожение";
                        case Word.distance: return "Расстояние";
                        case Word.fire: return "Огонь";
                        case Word.full: return "Полный";
                        case Word.game_over: return "Игра окончена";
                        case Word.health: return "Прочность";
                        case Word.music: return "Музыка";
                        case Word.pause: return "Пауза";
                        case Word.play: return "Играть";
                        case Word.quit: return "Выйти";
                        case Word.select: return "Выбрать";
                        case Word.selected: return "Выбрана";
                        case Word.settings: return "Настройки";
                        case Word.sfx: return "Звуки";
                        case Word.shop: return "Магазин";
                        case Word.special: return "Особое";
                        case Word.tasks: return "Задания";
                        case Word.total: return "Всего";
                        case Word.credits_text: return
                                "Иконка сделана Рынком Векторов с www.flaticon.com\n3D: www.cgtrader.com\n\nСоздатели: NikitaLnc и DoraLnc";

                        case Word.switch_account: return "Сменить аккаунт";
                        case Word.disk: return "Диск";
                        case Word.cloud: return "Облако";
                        case Word.best_distance: return "Лучшее расстояние";
                        case Word.last_visit: return "Последнее посещение";
                        case Word.name: return "Имя";
                        case Word.player_info: return "Информация об игроке";
                        case Word.enter_your_name: return "Введите ваше имя";
                        case Word.enter_new_name: return "Введите новое имя";
                        case Word.pay: return "Заплатить";
                        case Word.ok: return "Ок";
                        case Word.new_task_after: return "Новое задание через";
                        case Word.collect_gems: return "Собрать кристаллы";
                        case Word.deal_damage: return "Нанесение урона";
                        case Word.kill_monsters: return "Убивать монстров";
                        case Word.kill_zombies: return "Убить зомби";
                        case Word.reward: return "Награда";
                        case Word.privacy_policy: return "Политика конфиденциальности";
                        case Word.network_require: return "Требуется Интернет";
                        case Word.inventory: return "Инвентарь";

                        case Word.daily: return "Ежедневно";
                        case Word.weekly: return "Еженедельно";
                        case Word.you_got: return "Ты получил";
                        case Word.promo_code: return "Промокод";
                        case Word.the_promo_code_is_incorrect_or_used: return "Промокод неверный или использован";
                        case Word.fuel: return "Топливо";


                        default:
                            throw new NotImplementedException("Word don't exist!");
                    }

                case SystemLanguage.Romanian:
                    switch (word)
                    {
                        case Word.ads: return "Anunțuri";
                        case Word.brake: return "Frână";
                        case Word.buy: return "Cumpara";
                        case Word.capacity: return "Capacitate";
                        case Word.cars: return "Mașină";
                        case Word.continue_for: return "Continua pentru";
                        case Word.credits: return "Lista de atribute";
                        case Word.damage: return "Puterea deteriorării";
                        case Word.destroy: return "Deteriorare";
                        case Word.distance: return "Distanța";
                        case Word.fire: return "Trage";
                        case Word.full: return "Plin";
                        case Word.game_over: return "Jocul s-a terminat";
                        case Word.health: return "Putere";
                        case Word.music: return "Muzica";
                        case Word.pause: return "Pauză";
                        case Word.play: return "Joacă";
                        case Word.quit: return "Ieșire";
                        case Word.select: return "Selectează";
                        case Word.selected: return "Selectată";
                        case Word.settings: return "Setări";
                        case Word.sfx: return "Sunete";
                        case Word.shop: return "Magazin";
                        case Word.special: return "Altele";
                        case Word.tasks: return "Misiuni";
                        case Word.total: return "Toate";
                        case Word.credits_text:
                            return "Icoană realizată de Vectors Market de pe www.flaticon.com\n3D: www.cgtrader.com\n\nCreatori: NikitaLnc și DoraLnc";

                        case Word.switch_account: return "Schimbă contul";
                        case Word.disk: return "Disc";
                        case Word.cloud: return "Nor";
                        case Word.best_distance: return "Cea mai bună distanță";
                        case Word.last_visit: return "Ultima vizită";
                        case Word.name: return "Prenume";
                        case Word.player_info: return "Informații despre jucător";
                        case Word.enter_your_name: return "Introdu numele tău";
                        case Word.enter_new_name: return "Introduceți un nume nou";
                        case Word.pay: return "Achită";
                        case Word.ok: return "OK";
                        case Word.new_task_after: return "Nouă sarcină peste";
                        case Word.collect_gems: return "Colectați pietre prețioase";
                        case Word.deal_damage: return "Afectarea daunelor";
                        case Word.kill_monsters: return "Omoară monștri";
                        case Word.kill_zombies: return "Ucide-i pe zombi";
                        case Word.reward: return "Premiul";
                        case Word.privacy_policy: return "Politica de confidențialitate";
                        case Word.network_require: return "Internet necesar";
                        case Word.inventory: return "Inventar";

                        case Word.daily: return "Zilnic";
                        case Word.weekly: return "Săptămânal";
                        case Word.you_got: return "Tu ai primit";
                        case Word.promo_code: return "Cod promoțional";
                        case Word.the_promo_code_is_incorrect_or_used: return "Codul promo este incorect sau utilizat";
                        case Word.fuel: return "Combustibil";


                        default:
                            throw new NotImplementedException("Word don't exist!");
                    }

                case SystemLanguage.Turkish:
                    switch (word)
                    {
                        case Word.ads: return "Reklamlar";
                        case Word.brake: return "Fren";
                        case Word.buy: return "Satın";
                        case Word.capacity: return "Kapasite";
                        case Word.cars: return "Makine";
                        case Word.continue_for: return "Için devam et";
                        case Word.credits: return "Özellik listesi";
                        case Word.damage: return "Bitti";
                        case Word.destroy: return "Yok edilmesi";
                        case Word.distance: return "Mesafe";
                        case Word.fire: return "Ateş etmek";
                        case Word.full: return "Tam";
                        case Word.game_over: return "Oyun bitti";
                        case Word.health: return "Kuvvet";
                        case Word.music: return "Müzik";
                        case Word.pause: return "Duraklatma";
                        case Word.play: return "Oynamak";
                        case Word.quit: return "Dışarı çık";
                        case Word.select: return "Seçmek";
                        case Word.selected: return "Seçilmiş";
                        case Word.settings: return "Ayarlar";
                        case Word.sfx: return "Sesleri";
                        case Word.shop: return "Mağaza";
                        case Word.special: return "Özel";
                        case Word.tasks: return "Atamaları";
                        case Word.total: return "Tüm";
                        case Word.credits_text:
                            return "www.flaticon.com adresinden Vektörler Pazarı tarafından yapılan simge\n3D: www.cgtrader.com\n\nYaratıcılar: NikitaLnc ve DoraLnc";

                        case Word.switch_account: return "Hesabı değiştir";
                        case Word.disk: return "Disk";
                        case Word.cloud: return "Bulut";
                        case Word.best_distance: return "En iyi mesafe";
                        case Word.last_visit: return "Son ziyaret";
                        case Word.name: return "İlk isim";
                        case Word.player_info: return "Oyuncu Bilgileri";
                        case Word.enter_your_name: return "İsminizi girin";
                        case Word.enter_new_name: return "Yeni bir ad girin";
                        case Word.pay: return "Ödemek";
                        case Word.ok: return "Tamam";
                        case Word.new_task_after: return "Yeni görev";
                        case Word.collect_gems: return "Mücevher topla";
                        case Word.deal_damage: return "Hasar hasarı";
                        case Word.kill_monsters: return "Canavarları öldür";
                        case Word.kill_zombies: return "Zombileri öldür";
                        case Word.reward: return "Ödül";
                        case Word.privacy_policy: return "Gizlilik Politikası";
                        case Word.network_require: return "Internet Gerekli";
                        case Word.inventory: return "Envanter";

                        case Word.daily: return "Günlük";
                        case Word.weekly: return "Haftalık";
                        case Word.you_got: return "Sende var";
                        case Word.promo_code: return "Promosyon kodu";
                        case Word.the_promo_code_is_incorrect_or_used: return "Promosyon kodu yanlış veya kullanılmış";
                        case Word.fuel: return "Yakıt";


                        default:
                            throw new NotImplementedException("Word don't exist!");
                    }

                case SystemLanguage.Spanish:
                    switch (word)
                    {
                        case Word.ads: return "Anuncio";
                        case Word.brake: return "Freno";
                        case Word.buy: return "Comprar";
                        case Word.capacity: return "Capacidad";
                        case Word.cars: return "Carros";
                        case Word.continue_for: return "Continuar por";
                        case Word.credits: return "Lista de atributos";
                        case Word.damage: return "Daño";
                        case Word.destroy: return "Destrucción";
                        case Word.distance: return "Distancia";
                        case Word.fire: return "Disparar";
                        case Word.full: return "Lleno";
                        case Word.game_over: return "El juego ha terminado";
                        case Word.health: return "Fuerza";
                        case Word.music: return "Musica";
                        case Word.pause: return "Pausa";
                        case Word.play: return "Jugar";
                        case Word.quit: return "Salir";
                        case Word.select: return "Elegir";
                        case Word.selected: return "Seleccionado";
                        case Word.settings: return "Ajustes";
                        case Word.sfx: return "Suena";
                        case Word.shop: return "Tienda";
                        case Word.special: return "Especial";
                        case Word.tasks: return "Tareas";
                        case Word.total: return "Total";
                        case Word.credits_text:
                            return "Icono realizado por Vectors Market de www.flaticon.com\n3D: www.cgtrader.com\n\nCreadores: NikitaLnc y DoraLnc";

                        case Word.switch_account: return "Cambiar cuenta";
                        case Word.disk: return "Conducir";
                        case Word.cloud: return "Nube";
                        case Word.best_distance: return "Mejor distancia";
                        case Word.last_visit: return "Ultima visita";
                        case Word.name: return "Nombre";
                        case Word.player_info: return "Informacion del jugador";
                        case Word.enter_your_name: return "Escribe tu nombre";
                        case Word.enter_new_name: return "Ingrese un nuevo nombre";
                        case Word.pay: return "Pagar";
                        case Word.ok: return "Ok";
                        case Word.new_task_after: return "Nueva tarea a través de";
                        case Word.collect_gems: return "Recoger gemas";
                        case Word.deal_damage: return "Dañar daños";
                        case Word.kill_monsters: return "Matar monstruos";
                        case Word.kill_zombies: return "Mata a los zombies";
                        case Word.reward: return "Recompensa";
                        case Word.privacy_policy: return "Política de privacidad";
                        case Word.network_require: return "Requiere Internet";
                        case Word.inventory: return "Inventario";

                        case Word.daily: return "Diario";
                        case Word.weekly: return "Semanal";
                        case Word.you_got: return "Tu tienes";
                        case Word.promo_code: return "Código promocional";
                        case Word.the_promo_code_is_incorrect_or_used: return "El código promocional es incorrecto o usado";
                        case Word.fuel: return "Combustible";


                        default:
                            throw new NotImplementedException("Word don't exist!");
                    }

                case SystemLanguage.Portuguese:
                    switch (word)
                    {
                        case Word.ads: return "Anúncio";
                        case Word.brake: return "Freio";
                        case Word.buy: return "Comprar";
                        case Word.capacity: return "Capacidade";
                        case Word.cars: return "Carros";
                        case Word.continue_for: return "Continue por";
                        case Word.credits: return "Lista de atributos";
                        case Word.damage: return "Dano";
                        case Word.destroy: return "Destruição";
                        case Word.distance: return "Distância";
                        case Word.fire: return "Atirar";
                        case Word.full: return "Cheio";
                        case Word.game_over: return "O jogo acabou";
                        case Word.health: return "Força";
                        case Word.music: return "Música";
                        case Word.pause: return "Pausar";
                        case Word.play: return "Brincar";
                        case Word.quit: return "Sair";
                        case Word.select: return "Escolha";
                        case Word.selected: return "Selecionado";
                        case Word.settings: return "Configurações";
                        case Word.sfx: return "Sons";
                        case Word.shop: return "Loja";
                        case Word.special: return "Especial";
                        case Word.tasks: return "Tarefas";
                        case Word.total: return "Total";
                        case Word.credits_text:
                            return "Ícone criado pelo Vectors Market de www.flaticon.com\n3D: www.cgtrader.com\n\nCriadores: NikitaLnc e DoraLnc";

                        case Word.switch_account: return "Alterar conta";
                        case Word.disk: return "Drive";
                        case Word.cloud: return "Cloud";
                        case Word.best_distance: return "Melhor distância";
                        case Word.last_visit: return "Última visita";
                        case Word.name: return "Primeiro nome";
                        case Word.player_info: return "Informações do Jogador";
                        case Word.enter_your_name: return "Digite seu nome";
                        case Word.enter_new_name: return "Digite um novo nome";
                        case Word.pay: return "Pagar";
                        case Word.ok: return "Ok";
                        case Word.new_task_after: return "Nova tarefa através";
                        case Word.collect_gems: return "Colete gemas";
                        case Word.deal_damage: return "Dano causado";
                        case Word.kill_monsters: return "Mate monstros";
                        case Word.kill_zombies: return "Mate os zumbis";
                        case Word.reward: return "Recompensa";
                        case Word.privacy_policy: return "Política de privacidade";
                        case Word.network_require: return "Internet Necessária";
                        case Word.inventory: return "Inventário";

                        case Word.daily: return "Diariamente";
                        case Word.weekly: return "Semanal";
                        case Word.you_got: return "Você tem";
                        case Word.promo_code: return "Código promocional";
                        case Word.the_promo_code_is_incorrect_or_used: return "O código promocional está incorreto ou usado";
                        case Word.fuel: return "Combustível";


                        default:
                            throw new NotImplementedException("Word don't exist!");
                    }

                case SystemLanguage.French:
                    switch (word)
                    {
                        case Word.ads: return "Annonce";
                        case Word.brake: return "Frein";
                        case Word.buy: return "Acheter";
                        case Word.capacity: return "Capacité";
                        case Word.cars: return "Les voitures";
                        case Word.continue_for: return "Continuer pour";
                        case Word.credits: return "Liste d'attributs";
                        case Word.damage: return "Dommage";
                        case Word.destroy: return "Destruction";
                        case Word.distance: return "Distance";
                        case Word.fire: return "Tirer";
                        case Word.full: return "Plein";
                        case Word.game_over: return "Le jeu est terminé";
                        case Word.health: return "Force";
                        case Word.music: return "La musique";
                        case Word.pause: return "Pause";
                        case Word.play: return "Jouer";
                        case Word.quit: return "Sortir";
                        case Word.select: return "Choisissez";
                        case Word.selected: return "Sélectionné";
                        case Word.settings: return "Paramètres";
                        case Word.sfx: return "Des sons";
                        case Word.shop: return "Boutique";
                        case Word.special: return "Spécial";
                        case Word.tasks: return "Tâches";
                        case Word.total: return "Au total";
                        case Word.credits_text:
                            return "Icône réalisée par Vectors Market sur www.flaticon.com\n3D: www.cgtrader.com\n\nCréateurs: NikitaLnc et DoraLnc";

                        case Word.switch_account: return "Changer de compte";
                        case Word.disk: return "Conduire";
                        case Word.cloud: return "Nuage";
                        case Word.best_distance: return "Meilleure distance";
                        case Word.last_visit: return "Dernière visite";
                        case Word.name: return "Prénom";
                        case Word.player_info: return "Informations sur le joueur";
                        case Word.enter_your_name: return "Entrez votre nom";
                        case Word.enter_new_name: return "Entrez un nouveau nom";
                        case Word.pay: return "Payer";
                        case Word.ok: return "Ok";
                        case Word.new_task_after: return "Nouvelle tâche à travers";
                        case Word.collect_gems: return "Collectez des gemmes";
                        case Word.deal_damage: return "Infliger des dégâts";
                        case Word.kill_monsters: return "Tuez des monstres";
                        case Word.kill_zombies: return "Tuez les zombies";
                        case Word.reward: return "Récompense";
                        case Word.privacy_policy: return "Politique de confidentialité";
                        case Word.network_require: return "Internet Requis";
                        case Word.inventory: return "Inventaire";

                        case Word.daily: return "Du quotidien";
                        case Word.weekly: return "Hebdomadaire";
                        case Word.you_got: return "Vous avez";
                        case Word.promo_code: return "Code promo";
                        case Word.the_promo_code_is_incorrect_or_used: return "Le code promo est incorrect ou utilisé";
                        case Word.fuel: return "Carburant";


                        default:
                            throw new NotImplementedException("Word don't exist!");
                    }

                case SystemLanguage.German:
                    switch (word)
                    {
                        case Word.ads: return "Ad";
                        case Word.brake: return "Bremse";
                        case Word.buy: return "Kaufen";
                        case Word.capacity: return "Kapazität";
                        case Word.cars: return "Autos";
                        case Word.continue_for: return "Weiter für";
                        case Word.credits: return "Attribut liste";
                        case Word.damage: return "Schaden";
                        case Word.destroy: return "Zerstörung";
                        case Word.distance: return "Entfernung";
                        case Word.fire: return "Zu schießen";
                        case Word.full: return "Voll";
                        case Word.game_over: return "Das spiel ist beendet";
                        case Word.health: return "Stärke";
                        case Word.music: return "Musik";
                        case Word.pause: return "Pause";
                        case Word.play: return "Spielen";
                        case Word.quit: return "Raus";
                        case Word.select: return "Wählen sie";
                        case Word.selected: return "Ausgewählt";
                        case Word.settings: return "Einstellungen";
                        case Word.sfx: return "Klingt";
                        case Word.shop: return "Einkaufen";
                        case Word.special: return "Speziell";
                        case Word.tasks: return "Aufgaben";
                        case Word.total: return "Insgesamt";
                        case Word.credits_text:
                            return "Symbol von Vectors Market von www.flaticon.com\n3D: www.cgtrader.com\n\nSchöpfer: NikitaLnc und DoraLnc";

                        case Word.switch_account: return "Konto ändern";
                        case Word.disk: return "Fahren";
                        case Word.cloud: return "Wolke";
                        case Word.best_distance: return "Beste Entfernung";
                        case Word.last_visit: return "Letzter Besuch";
                        case Word.name: return "Vorname";
                        case Word.player_info: return "Spielerinformationen";
                        case Word.enter_your_name: return "Geben Sie Ihren Namen ein";
                        case Word.enter_new_name: return "Geben Sie einen neuen Namen ein";
                        case Word.pay: return "Zu bezahlen";
                        case Word.ok: return "Ok";
                        case Word.new_task_after: return "Neue Aufgabe durch";
                        case Word.collect_gems: return "Sammle Edelsteine";
                        case Word.deal_damage: return "Handelsschaden";
                        case Word.kill_monsters: return "Töte Monster";
                        case Word.kill_zombies: return "Töte die Zombies";
                        case Word.reward: return "Belohnung";
                        case Word.privacy_policy: return "Datenschutzerklärung";
                        case Word.network_require: return "Internet Erforderlich";
                        case Word.inventory: return "Inventar";

                        case Word.daily: return "Täglich";
                        case Word.weekly: return "Wöchentlich";
                        case Word.you_got: return "Du hast es bekommen";
                        case Word.promo_code: return "Werbe-Code";
                        case Word.the_promo_code_is_incorrect_or_used: return "Der Promo-Code ist falsch oder wird verwendet";
                        case Word.fuel: return "Treibstoff";


                        default:
                            throw new NotImplementedException("Word don't exist!");
                    }

                case SystemLanguage.Italian:
                    switch (word)
                    {
                        case Word.ads: return "Annunci";
                        case Word.brake: return "Freni";
                        case Word.buy: return "Acquista";
                        case Word.capacity: return "Capacità";
                        case Word.cars: return "La macchina";
                        case Word.continue_for: return "Continuare per";
                        case Word.credits: return "Elenco di attributi";
                        case Word.damage: return "Fatto";
                        case Word.destroy: return "La distruzione";
                        case Word.distance: return "La distanza";
                        case Word.fire: return "Sparare";
                        case Word.full: return "Pieno";
                        case Word.game_over: return "Il gioco è finito";
                        case Word.health: return "Forza";
                        case Word.music: return "Musica";
                        case Word.pause: return "Pausa";
                        case Word.play: return "Giocare";
                        case Word.quit: return "Uscire";
                        case Word.select: return "Selezionare";
                        case Word.selected: return "Selezionato";
                        case Word.settings: return "Impostazioni";
                        case Word.sfx: return "Suoni";
                        case Word.shop: return "Negozio";
                        case Word.special: return "Speciale";
                        case Word.tasks: return "Assegnazioni";
                        case Word.total: return "Tutto";
                        case Word.credits_text:
                            return "Icona realizzata dal mercato dei vettori da www.flaticon.com\n3D: www.cgtrader.com\n\nCreatori: NikitaLnc e DoraLnc";

                        case Word.switch_account: return "Cambia account";
                        case Word.disk: return "Disco";
                        case Word.cloud: return "Nuvola";
                        case Word.best_distance: return "Distanza migliore";
                        case Word.last_visit: return "Ultima visita";
                        case Word.name: return "Nome";
                        case Word.player_info: return "Informazioni sul giocatore";
                        case Word.enter_your_name: return "Inserisci il tuo nome";
                        case Word.enter_new_name: return "Inserisci un nuovo nome";
                        case Word.pay: return "Da pagare";
                        case Word.ok: return "ok";
                        case Word.new_task_after: return "Nuova attività tramite";
                        case Word.collect_gems: return "Colleziona gemme";
                        case Word.deal_damage: return "Danni da infliggere";
                        case Word.kill_monsters: return "Uccidi i mostri";
                        case Word.kill_zombies: return "Uccidi gli zombi";
                        case Word.reward: return "Il premio";
                        case Word.privacy_policy: return "Politica sulla privacy";
                        case Word.network_require: return "Internet Richiesto";
                        case Word.inventory: return "Inventario";

                        case Word.daily: return "Quotidiano";
                        case Word.weekly: return "Settimanalmente";
                        case Word.you_got: return "Tu hai";
                        case Word.promo_code: return "Codice promozionale";
                        case Word.the_promo_code_is_incorrect_or_used: return "Il codice promozionale non è corretto o utilizzato";
                        case Word.fuel: return "Carburante";


                        default:
                            throw new NotImplementedException("Word don't exist!");
                    }

                case SystemLanguage.Ukrainian:
                    switch (word)
                    {
                        case Word.ads: return "Оголошення";
                        case Word.brake: return "Гальмо";
                        case Word.buy: return "Купити";
                        case Word.capacity: return "Місткість";
                        case Word.cars: return "Машини";
                        case Word.continue_for: return "Продовжити за";
                        case Word.credits: return "Список атрибутів";
                        case Word.damage: return "Шкоди";
                        case Word.destroy: return "Знищення";
                        case Word.distance: return "Відстань";
                        case Word.fire: return "Стріляти";
                        case Word.full: return "Повний";
                        case Word.game_over: return "Гру закінчено";
                        case Word.health: return "Міцність";
                        case Word.music: return "Музика";
                        case Word.pause: return "Пауза";
                        case Word.play: return "Грати";
                        case Word.quit: return "Вийти";
                        case Word.select: return "Вибрати";
                        case Word.selected: return "Обрана";
                        case Word.settings: return "Настройки";
                        case Word.sfx: return "Звуки";
                        case Word.shop: return "Магазин";
                        case Word.special: return "Особливе";
                        case Word.tasks: return "Завдання";
                        case Word.total: return "За все";
                        case Word.credits_text:
                            return "Ікона, зроблена Вектором Маркет з www.flaticon.com\n3D: www.cgtrader.com\n\nТворці: NikitaLnc та DoraLnc";

                        case Word.switch_account: return "Змінити акаунт";
                        case Word.disk: return "Диск";
                        case Word.cloud: return "Хмара";
                        case Word.best_distance: return "Найкраще відстань";
                        case Word.last_visit: return "Останнє відвідування";
                        case Word.name: return "Iм'я";
                        case Word.player_info: return "Інформація про гравця";
                        case Word.enter_your_name: return "Введіть ваше ім'я";
                        case Word.enter_new_name: return "Введіть нове ім'я";
                        case Word.pay: return "Заплатити";
                        case Word.ok: return "Ок";
                        case Word.new_task_after: return "Нове завдання через";
                        case Word.collect_gems: return "Збирайте дорогоцінні камені";
                        case Word.deal_damage: return "Нанесення шкоди";
                        case Word.kill_monsters: return "Вбивати монстрів";
                        case Word.kill_zombies: return "Вбити зомбі";
                        case Word.reward: return "Нагорода";
                        case Word.privacy_policy: return "Політика конфіденційності";
                        case Word.network_require: return "Інтернет Необхідний";
                        case Word.inventory: return "Инвентар";

                        case Word.daily: return "Щодня";
                        case Word.weekly: return "Щотижня";
                        case Word.you_got: return "Ти отримав";
                        case Word.promo_code: return "Промокод";
                        case Word.the_promo_code_is_incorrect_or_used: return "Промокод невірний або використаний";
                        case Word.fuel: return "Паливо";


                        default:
                            throw new NotImplementedException("Word don't exist!");
                    }

                case SystemLanguage.Polish:
                    switch (word)
                    {
                        case Word.ads: return "Ad";
                        case Word.brake: return "Hamulec";
                        case Word.buy: return "Kup";
                        case Word.capacity: return "Pojemność";
                        case Word.cars: return "Samochody";
                        case Word.continue_for: return "Kontynuować dla";
                        case Word.credits: return "Lista atrybutów";
                        case Word.damage: return "Uszkodzenie";
                        case Word.destroy: return "Zniszczenie";
                        case Word.distance: return "Odległość";
                        case Word.fire: return "Strzelać";
                        case Word.full: return "Pełny";
                        case Word.game_over: return "Gra się skończyła";
                        case Word.health: return "Siła";
                        case Word.music: return "Muzyka";
                        case Word.pause: return "Pauza";
                        case Word.play: return "Grać";
                        case Word.quit: return "Wynoś się";
                        case Word.select: return "Wybierz";
                        case Word.selected: return "Wybrane";
                        case Word.settings: return "Ustawienia";
                        case Word.sfx: return "Brzmi";
                        case Word.shop: return "Sklep";
                        case Word.special: return "Specjalne";
                        case Word.tasks: return "Zadania";
                        case Word.total: return "Łącznie";
                        case Word.credits_text:
                            return "Ikona wykonana przez Vectors Market z www.flaticon.com\n3D: www.cgtrader.com\n\nTwórcy: NikitaLnc i DoraLnc";

                        case Word.switch_account: return "Zmień konto";
                        case Word.disk: return "Jedź";
                        case Word.cloud: return "Chmura";
                        case Word.best_distance: return "Najlepsza odległość";
                        case Word.last_visit: return "Ostatnia wizyta";
                        case Word.name: return "Imię";
                        case Word.player_info: return "Informacje o graczu";
                        case Word.enter_your_name: return "Wpisz swoje imię";
                        case Word.enter_new_name: return "Wpisz nową nazwę";
                        case Word.pay: return "Do zapłaty";
                        case Word.ok: return "Okej";
                        case Word.new_task_after: return "Nowe zadanie poprzez";
                        case Word.collect_gems: return "Zbieraj klejnoty";
                        case Word.deal_damage: return "Zadawanie obrażeń";
                        case Word.kill_monsters: return "Zabij potwory";
                        case Word.kill_zombies: return "Zabij zombie";
                        case Word.reward: return "Nagroda";
                        case Word.privacy_policy: return "Polityka prywatności";
                        case Word.network_require: return "Wymagany Internet";
                        case Word.inventory: return "Inwentarz";

                        case Word.daily: return "Codziennie";
                        case Word.weekly: return "Co tydzień";
                        case Word.you_got: return "Masz";
                        case Word.promo_code: return "Kod promocyjny";
                        case Word.the_promo_code_is_incorrect_or_used: return "Kod promocyjny jest nieprawidłowy lub wykorzystany";
                        case Word.fuel: return "Paliwo";


                        default:
                            throw new NotImplementedException("Word don't exist!");
                    }

                case SystemLanguage.Swedish:
                    switch (word)
                    {
                        case Word.ads: return "Annonser";
                        case Word.brake: return "Broms";
                        case Word.buy: return "Köp";
                        case Word.capacity: return "Kapacitet";
                        case Word.cars: return "Maskin";
                        case Word.continue_for: return "Fortsätt för";
                        case Word.credits: return "Attributlista";
                        case Word.damage: return "Klar";
                        case Word.destroy: return "Förstörelse";
                        case Word.distance: return "Avstånd";
                        case Word.fire: return "Att skjuta";
                        case Word.full: return "Fullt";
                        case Word.game_over: return "Spelet är över";
                        case Word.health: return "Styrka";
                        case Word.music: return "Musik";
                        case Word.pause: return "Pausa";
                        case Word.play: return "Spela";
                        case Word.quit: return "Gå ut";
                        case Word.select: return "Välj";
                        case Word.selected: return "Vald";
                        case Word.settings: return "Inställningar";
                        case Word.sfx: return "Ljud";
                        case Word.shop: return "Butik";
                        case Word.special: return "Speciell";
                        case Word.tasks: return "Uppdrag";
                        case Word.total: return "Allt";
                        case Word.credits_text:
                            return "Ikon tillverkad av Vectors Market från www.flaticon.com\n3D: www.cgtrader.com\n\nSkapare: NikitaLnc och DoraLnc";

                        case Word.switch_account: return "Byt konto";
                        case Word.disk: return "Disk";
                        case Word.cloud: return "Moln";
                        case Word.best_distance: return "Bästa avstånd";
                        case Word.last_visit: return "Senaste besök";
                        case Word.name: return "Förnamn";
                        case Word.player_info: return "Spelarinformation";
                        case Word.enter_your_name: return "Ange ditt namn";
                        case Word.enter_new_name: return "Ange ett nytt namn";
                        case Word.pay: return "Att betala";
                        case Word.ok: return "ok";
                        case Word.new_task_after: return "Ny uppgift genom";
                        case Word.collect_gems: return "Samla ädelstenar";
                        case Word.deal_damage: return "Hanteringsskador";
                        case Word.kill_monsters: return "Döda monster";
                        case Word.kill_zombies: return "Döda zombies";
                        case Word.reward: return "Priset";
                        case Word.privacy_policy: return "Integritetspolicy";
                        case Word.network_require: return "Internet krävs";
                        case Word.inventory: return "Lager";

                        case Word.daily: return "Dagligen";
                        case Word.weekly: return "Varje vecka";
                        case Word.you_got: return "Du har";
                        case Word.promo_code: return "Rabattkod";
                        case Word.the_promo_code_is_incorrect_or_used: return "Kampanjkoden är felaktig eller används";
                        case Word.fuel: return "Bränsle";


                        default:
                            throw new NotImplementedException("Word don't exist!");
                    }

                case SystemLanguage.ChineseSimplified:
                    switch (word)
                    {
                        case Word.ads: return "广告";
                        case Word.brake: return "煞车";
                        case Word.buy: return "买";
                        case Word.capacity: return "容量";
                        case Word.cars: return "汽车";
                        case Word.continue_for: return "继续";
                        case Word.credits: return "属性列表";
                        case Word.damage: return "破坏";
                        case Word.destroy: return "毁灭";
                        case Word.distance: return "距离";
                        case Word.fire: return "射击";
                        case Word.full: return "满满的";
                        case Word.game_over: return "游戏结束了";
                        case Word.health: return "实力";
                        case Word.music: return "乐曲";
                        case Word.pause: return "暂停";
                        case Word.play: return "玩";
                        case Word.quit: return "下车";
                        case Word.select: return "选择";
                        case Word.selected: return "已选";
                        case Word.settings: return "设定";
                        case Word.sfx: return "声音";
                        case Word.shop: return "铺";
                        case Word.special: return "特别的";
                        case Word.tasks: return "任务";
                        case Word.total: return "合计";
                        case Word.credits_text: 
                            return "由Vectors Market从www.flaticon.com制造的图标\n3D：www.cgtrader.com\n\n创建者：NikitaLnc和DoraLnc";

                        case Word.switch_account: return "变更账户";
                        case Word.disk: return "驱动器";
                        case Word.cloud: return "云";
                        case Word.best_distance: return "最佳距离";
                        case Word.last_visit: return "最后访问";
                        case Word.name: return "名";
                        case Word.player_info: return "玩家信息";
                        case Word.enter_your_name: return "输入你的名字";
                        case Word.enter_new_name: return "输入新名称";
                        case Word.pay: return "支付";
                        case Word.ok: return "好啦";
                        case Word.new_task_after: return "通过新任务";
                        case Word.collect_gems: return "收集宝石";
                        case Word.deal_damage: return "造成伤害";
                        case Word.kill_monsters: return "杀死怪物";
                        case Word.kill_zombies: return "杀死僵尸";
                        case Word.reward: return "奖赏";
                        case Word.privacy_policy: return "私隐政策";
                        case Word.network_require: return "需要互联网";
                        case Word.inventory: return "库存";

                        case Word.daily: return "日常";
                        case Word.weekly: return "每周";
                        case Word.you_got: return "你得到了";
                        case Word.promo_code: return "促销代码";
                        case Word.the_promo_code_is_incorrect_or_used: return "促销代码不正确或已使用";
                        case Word.fuel: return "汽油";


                        default:
                            throw new NotImplementedException("Word don't exist!");
                    }

                case SystemLanguage.Belarusian:
                    switch (word)
                    {
                        case Word.ads: return "Аб'яву";
                        case Word.brake: return "Тормаз";
                        case Word.buy: return "Купіць";
                        case Word.capacity: return "Ўмяшчальнасць";
                        case Word.cars: return "Машыны";
                        case Word.continue_for: return "Працягнуць за";
                        case Word.credits: return "Спіс атрыбутаў";
                        case Word.damage: return "Страты";
                        case Word.destroy: return "Знішчэнне";
                        case Word.distance: return "Адлегласць";
                        case Word.fire: return "Страляць";
                        case Word.full: return "Поўны";
                        case Word.game_over: return "Гульня скончаная";
                        case Word.health: return "Трываласць";
                        case Word.music: return "Музыка";
                        case Word.pause: return "Паўза";
                        case Word.play: return "Гуляць";
                        case Word.quit: return "Выйсці";
                        case Word.select: return "Выбраць";
                        case Word.selected: return "Абраная";
                        case Word.settings: return "Налады";
                        case Word.sfx: return "Гукі";
                        case Word.shop: return "Крама";
                        case Word.special: return "Асаблівую";
                        case Word.tasks: return "Заданні";
                        case Word.total: return "За ўсё";
                        case Word.credits_text:
                            return "Абраз, зроблены кампаніяй Vectors Market з www.flaticon.com\n3D: www.cgtrader.com\n\nСтваральнікі: NikitaLnc і DoraLnc";

                        case Word.switch_account: return "Змяніць рахунак";
                        case Word.disk: return "Дыск";
                        case Word.cloud: return "Воблака";
                        case Word.best_distance: return "Лепшае адлегласць";
                        case Word.last_visit: return "Апошняе наведванне";
                        case Word.name: return "Iмя";
                        case Word.player_info: return "Інфармацыя аб гульцу";
                        case Word.enter_your_name: return "Калі ласка, увядзіце ваша імя";
                        case Word.enter_new_name: return "Калі ласка, увядзіце новае імя";
                        case Word.pay: return "Заплаціць";
                        case Word.ok: return "Ок";
                        case Word.new_task_after: return "Новае заданне праз";
                        case Word.collect_gems: return "Збірайце каштоўныя камяні";
                        case Word.deal_damage: return "Нанясенне ўрону";
                        case Word.kill_monsters: return "Забіваць монстраў";
                        case Word.kill_zombies: return "Забіць зомбі";
                        case Word.reward: return "Узнагарода";
                        case Word.privacy_policy: return "Палітыка прыватнасці";
                        case Word.network_require: return "Інтэрнэт патрабуецца";
                        case Word.inventory: return "Iнвентар";

                        case Word.daily: return "Штодня";
                        case Word.weekly: return "Штотыдзень";
                        case Word.you_got: return "Ты атрымаў";
                        case Word.promo_code: return "Промокод";
                        case Word.the_promo_code_is_incorrect_or_used: return "Промокод няправільны ці скарыстаны";
                        case Word.fuel: return "Паліва";


                        default:
                            throw new NotImplementedException("Word don't exist!");
                    }

                case SystemLanguage.Czech:
                    switch (word)
                    {
                        case Word.ads: return "Ad";
                        case Word.brake: return "Brzda";
                        case Word.buy: return "Koupit";
                        case Word.capacity: return "Kapacita";
                        case Word.cars: return "Auta";
                        case Word.continue_for: return "Pokračovat";
                        case Word.credits: return "Seznam atributů";
                        case Word.damage: return "Poškození";
                        case Word.destroy: return "Zničení";
                        case Word.distance: return "Vzdálenost";
                        case Word.fire: return "Střílet";
                        case Word.full: return "Plný";
                        case Word.game_over: return "Hra skončila";
                        case Word.health: return "Síla";
                        case Word.music: return "Hudba";
                        case Word.pause: return "Pauza";
                        case Word.play: return "Hrát";
                        case Word.quit: return "Vypadni";
                        case Word.select: return "Vyberte si";
                        case Word.selected: return "Vybrané";
                        case Word.settings: return "Nastavení";
                        case Word.sfx: return "Zní";
                        case Word.shop: return "Obchod";
                        case Word.special: return "Speciální";
                        case Word.tasks: return "Úkoly";
                        case Word.total: return "Сelkem";
                        case Word.credits_text:
                            return "Ikona společnosti Vector Market z webu www.flaticon.com\n3D: www.cgtrader.com\n\nTvůrci: NikitaLnc a DoraLnc";

                        case Word.switch_account: return "Změnit účet";
                        case Word.disk: return "Řídit";
                        case Word.cloud: return "Cloud";
                        case Word.best_distance: return "Nejlepší vzdálenost";
                        case Word.last_visit: return "Poslední návštěva";
                        case Word.name: return "Křestní jméno";
                        case Word.player_info: return "Informace o hráči";
                        case Word.enter_your_name: return "Zadejte své jméno";
                        case Word.enter_new_name: return "Zadejte nové jméno";
                        case Word.pay: return "Platit";
                        case Word.ok: return "Dobře";
                        case Word.new_task_after: return "Nový úkol prostřednictvím";
                        case Word.collect_gems: return "Sbírejte drahokamy";
                        case Word.deal_damage: return "Odstraňování škod";
                        case Word.kill_monsters: return "Zabijte příšery";
                        case Word.kill_zombies: return "Zabijte zombie";
                        case Word.reward: return "Odměna";
                        case Word.privacy_policy: return "Zásady ochrany osobních údajů";
                        case Word.network_require: return "Je vyžadován internet";
                        case Word.inventory: return "Inventář";

                        case Word.daily: return "Denně";
                        case Word.weekly: return "Týdně";
                        case Word.you_got: return "Máš";
                        case Word.promo_code: return "Promo kód";
                        case Word.the_promo_code_is_incorrect_or_used: return "Promo kód je nesprávný nebo použitý";
                        case Word.fuel: return "Palivo";


                        default:
                            throw new NotImplementedException("Word don't exist!");
                    }

                case SystemLanguage.Greek:
                    switch (word)
                    {
                        case Word.ads: return "Διαφήμιση";
                        case Word.brake: return "Φρένο";
                        case Word.buy: return "Αγορά";
                        case Word.capacity: return "Χωρητικότητα";
                        case Word.cars: return "Αυτοκίνητα";
                        case Word.continue_for: return "Συνεχίστε για";
                        case Word.credits: return "Λίστα χαρακτηριστικών";
                        case Word.damage: return "Zημιά";
                        case Word.destroy: return "Καταστροφή";
                        case Word.distance: return "Απόσταση";
                        case Word.fire: return "Για να πυροβολήσεις";
                        case Word.full: return "Πλήρης";
                        case Word.game_over: return "Το παιχνίδι τελείωσε";
                        case Word.health: return "Δύναμη";
                        case Word.music: return "Μουσική";
                        case Word.pause: return "Παύση";
                        case Word.play: return "Παίξτε";
                        case Word.quit: return "Βγες έξω";
                        case Word.select: return "Επιλέξτε";
                        case Word.selected: return "Επιλεγμένο";
                        case Word.settings: return "Ρυθμίσεις";
                        case Word.sfx: return "Ακούγεται";
                        case Word.shop: return "Αγορά";
                        case Word.special: return "Ειδικό";
                        case Word.tasks: return "Εργασίες";
                        case Word.total: return "Σύνολο";
                        case Word.credits_text:
                            return "Εικονίδιο της Vectors Market από το www.flaticon.com\n3D: www.cgtrader.com\n\nΔημιουργοί: NikitaLnc και DoraLnc";

                        case Word.switch_account: return "Αλλαγή λογαριασμού";
                        case Word.disk: return "Οδήγηση";
                        case Word.cloud: return "Σύννεφο";
                        case Word.best_distance: return "Καλύτερη απόσταση";
                        case Word.last_visit: return "Τελευταία επίσκεψη";
                        case Word.name: return "Όνομα";
                        case Word.player_info: return "Πληροφορίες παίκτη";
                        case Word.enter_your_name: return "Εισαγάγετε το όνομά σας";
                        case Word.enter_new_name: return "Εισαγάγετε ένα νέο όνομα";
                        case Word.pay: return "Για να πληρώσετε";
                        case Word.ok: return "Εντάξει";
                        case Word.new_task_after: return "Νέα εργασία μέσω";
                        case Word.collect_gems: return "Συλλέξτε πολύτιμους λίθους";
                        case Word.deal_damage: return "Αντιμετώπιση ζημιών";
                        case Word.kill_monsters: return "Σκότωσε τέρατα";
                        case Word.kill_zombies: return "Σκότωσε τα ζόμπι";
                        case Word.reward: return "Ανταμοιβή";
                        case Word.privacy_policy: return "Πολιτική απορρήτου";
                        case Word.network_require: return "Απαιτείται Διαδίκτυο";
                        case Word.inventory: return "καταγραφή εμπορευμάτων";

                        case Word.daily: return "καθημερινά";
                        case Word.weekly: return "εβδομαδιαίος";
                        case Word.you_got: return "έχεις";
                        case Word.promo_code: return "κωδικός προσφοράς";
                        case Word.the_promo_code_is_incorrect_or_used: return "ο κωδικός προσφοράς είναι λανθασμένος ή χρησιμοποιείται";
                        case Word.fuel: return "καύσιμα";


                        default:
                            throw new NotImplementedException("Word don't exist!");
                    }

                case SystemLanguage.Indonesian:
                    switch (word)
                    {
                        case Word.ads: return "Iklan";
                        case Word.brake: return "Rem";
                        case Word.buy: return "Beli";
                        case Word.capacity: return "Kapasitas";
                        case Word.cars: return "Mobil";
                        case Word.continue_for: return "Lanjutkan untuk";
                        case Word.credits: return "Daftar atribut";
                        case Word.damage: return "Kerusakan";
                        case Word.destroy: return "Penghancuran";
                        case Word.distance: return "Jarak";
                        case Word.fire: return "Untuk menembak";
                        case Word.full: return "Penuh";
                        case Word.game_over: return "Permainan sudah berakhir";
                        case Word.health: return "Kekuatan";
                        case Word.music: return "Musik";
                        case Word.pause: return "Jeda";
                        case Word.play: return "Mainkan";
                        case Word.quit: return "Keluar";
                        case Word.select: return "Pilih";
                        case Word.selected: return "Dipilih";
                        case Word.settings: return "Pengaturan";
                        case Word.sfx: return "Terdengar";
                        case Word.shop: return "Toko";
                        case Word.special: return "Spesial";
                        case Word.tasks: return "Tugas";
                        case Word.total: return "Total";
                        case Word.credits_text:
                            return "Ikon yang dibuat oleh Vektor Market dari www.flaticon.com\n3D: www.cgtrader.com\n\nPembuat: NikitaLnc dan DoraLnc";

                        case Word.switch_account: return "Ubah akun";
                        case Word.disk: return "Berkendara";
                        case Word.cloud: return "Cloud";
                        case Word.best_distance: return "Jarak terbaik";
                        case Word.last_visit: return "Kunjungan terakhir";
                        case Word.name: return "Nama depan";
                        case Word.player_info: return "Informasi Pemain";
                        case Word.enter_your_name: return "Masukkan nama Anda";
                        case Word.enter_new_name: return "Masukkan nama baru";
                        case Word.pay: return "Untuk membayar";
                        case Word.ok: return "Ok";
                        case Word.new_task_after: return "Tugas baru melalui";
                        case Word.collect_gems: return "Kumpulkan permata";
                        case Word.deal_damage: return "Ambil airnya";
                        case Word.kill_monsters: return "Bunuh monster";
                        case Word.kill_zombies: return "Bunuh zombie";
                        case Word.reward: return "Hadiah";
                        case Word.privacy_policy: return "Kebijakan privasi";
                        case Word.network_require: return "Diperlukan internet";
                        case Word.inventory: return "Inventaris";

                        case Word.daily: return "Harian";
                        case Word.weekly: return "Mingguan";
                        case Word.you_got: return "Kamu punya";
                        case Word.promo_code: return "Kode promosi";
                        case Word.the_promo_code_is_incorrect_or_used: return "kode promo salah atau digunakan";
                        case Word.fuel: return "bahan bakar";


                        default:
                            throw new NotImplementedException("Word don't exist!");
                    }

                case SystemLanguage.Japanese:
                    switch (word)
                    {
                        case Word.ads: return "広告";
                        case Word.brake: return "ブレーキ";
                        case Word.buy: return "購入、";
                        case Word.capacity: return "容量";
                        case Word.cars: return "車";
                        case Word.continue_for: return "続く";
                        case Word.credits: return "属性リスト";
                        case Word.damage: return "ダメージ";
                        case Word.destroy: return "破壊";
                        case Word.distance: return "距離";
                        case Word.fire: return "撮影する";
                        case Word.full: return "いっぱい";
                        case Word.game_over: return "ゲームは終わった";
                        case Word.health: return "強さ";
                        case Word.music: return "音楽";
                        case Word.pause: return "一時停止";
                        case Word.play: return "遊ぶ";
                        case Word.quit: return "外出";
                        case Word.select: return "選ぶ";
                        case Word.selected: return "選択済み";
                        case Word.settings: return "設定";
                        case Word.sfx: return "音";
                        case Word.shop: return "ショップ";
                        case Word.special: return "特別な";
                        case Word.tasks: return "タスク";
                        case Word.total: return "合計";
                        case Word.credits_text:
                            return "www.flaticon.comのVectors Marketが作成したアイコン\n3D：www.cgtrader.com\n\n作成者：NikitaLncおよびDoraLnc";

                        case Word.switch_account: return "アカウントを変更";
                        case Word.disk: return "ドライブ";
                        case Word.cloud: return "雲";
                        case Word.best_distance: return "最短距離";
                        case Word.last_visit: return "最後の訪問";
                        case Word.name: return "名";
                        case Word.player_info: return "プレイヤー情報";
                        case Word.enter_your_name: return "あなたの名前を入力してください、";
                        case Word.enter_new_name: return "新しい名前を入力し、";
                        case Word.pay: return "支払う";
                        case Word.ok: return "よし";
                        case Word.new_task_after: return "新しいタスク、";
                        case Word.collect_gems: return "宝石を集める";
                        case Word.deal_damage: return "ダメージを与える";
                        case Word.kill_monsters: return "モンスターを殺す";
                        case Word.kill_zombies: return "ゾンビを殺す";
                        case Word.reward: return "報酬";
                        case Word.privacy_policy: return "プライバシーポリシー";
                        case Word.network_require: return "インターネットが必要";
                        case Word.inventory: return "在庫";

                        case Word.daily: return "毎日";
                        case Word.weekly: return "毎週";
                        case Word.you_got: return "あなたが得た";
                        case Word.promo_code: return "プロモーションコード";
                        case Word.the_promo_code_is_incorrect_or_used: return "あなたが得た、プロモーションコード、プロモーションコードが正しくないか使用されている";
                        case Word.fuel: return "燃料";


                        default:
                            throw new NotImplementedException("Word don't exist!");
                    }

                case SystemLanguage.Korean:
                    switch (word)
                    {
                        case Word.ads: return "광고";
                        case Word.brake: return "브레이크";
                        case Word.buy: return "구매";
                        case Word.capacity: return "용량";
                        case Word.cars: return "자동차";
                        case Word.continue_for: return "계속";
                        case Word.credits: return "속성 목록";
                        case Word.damage: return "피해";
                        case Word.destroy: return "파괴";
                        case Word.distance: return "거리";
                        case Word.fire: return "쏴";
                        case Word.full: return "전체";
                        case Word.game_over: return "게임은 끝났다";
                        case Word.health: return "힘";
                        case Word.music: return "음악";
                        case Word.pause: return "일시 중지";
                        case Word.play: return "플레이";
                        case Word.quit: return "외출";
                        case Word.select: return "선택";
                        case Word.selected: return "선정";
                        case Word.settings: return "설정";
                        case Word.sfx: return "소리";
                        case Word.shop: return "쇼핑";
                        case Word.special: return "스페셜";
                        case Word.tasks: return "작업";
                        case Word.total: return "총계";
                        case Word.credits_text:
                            return "www.flaticon.com에서 Vectors Market이 만든 아이콘\n3D : www.cgtrader.com\n\n제작자 : NikitaLnc 및 DoraLnc";

                        case Word.switch_account: return "계정 변경";
                        case Word.disk: return "드라이브";
                        case Word.cloud: return "구름";
                        case Word.best_distance: return "최고의 거리";
                        case Word.last_visit: return "마지막 방문";
                        case Word.name: return "이름";
                        case Word.player_info: return "선수 정보";
                        case Word.enter_your_name: return "이름을 입력하고";
                        case Word.enter_new_name: return "새로운 이름을 입력하고";
                        case Word.pay: return "지불";
                        case Word.ok: return "알았어";
                        case Word.new_task_after: return "통해 새로운 작업";
                        case Word.collect_gems: return "보석 수집";
                        case Word.deal_damage: return "다루는 피해";
                        case Word.kill_monsters: return "몬스터 처치";
                        case Word.kill_zombies: return "좀비를 죽여라";
                        case Word.reward: return "보상";
                        case Word.privacy_policy: return "개인 정보 보호 정책";
                        case Word.network_require: return "인터넷 필요";
                        case Word.inventory: return "목록";

                        case Word.daily: return "매일";
                        case Word.weekly: return "주간";
                        case Word.you_got: return "당신은 얻었다";
                        case Word.promo_code: return "프로모션 코드";
                        case Word.the_promo_code_is_incorrect_or_used: return "프로모션 코드가 잘못되었거나 사용되었습니다";
                        case Word.fuel: return "연료";


                        default:
                            throw new NotImplementedException("Word don't exist!");
                    }

                case SystemLanguage.Arabic:
                    switch (word)
                    {
                        case Word.ads: return "إعلان";
                        case Word.brake: return "الفرامل";
                        case Word.buy: return "شراء ،";
                        case Word.capacity: return "القدرة";
                        case Word.cars: return "سيارات";
                        case Word.continue_for: return "تواصل ل";
                        case Word.credits: return "قائمة السمات";
                        case Word.damage: return "الضرر";
                        case Word.destroy: return "دمار";
                        case Word.distance: return "المسافة";
                        case Word.fire: return "لاطلاق النار";
                        case Word.full: return "كامل";
                        case Word.game_over: return "انتهت اللعبة";
                        case Word.health: return "القوة";
                        case Word.music: return "موسيقى";
                        case Word.pause: return "وقفة";
                        case Word.play: return "العب";
                        case Word.quit: return "اخرج";
                        case Word.select: return "اختر";
                        case Word.selected: return "تم التحديد";
                        case Word.settings: return "الإعدادات";
                        case Word.sfx: return "يبدو";
                        case Word.shop: return "تسوق";
                        case Word.special: return "خاص";
                        case Word.tasks: return "المهام";
                        case Word.total: return "المجموع";
                        case Word.credits_text:
                            return "أيقونة صنعها فيكتورس ماركت من \nwww.flaticon.com\n3D: www.cgtrader.com\n\nالتأليف: NikitaLnc و \nDoraLnc";

                        case Word.switch_account: return "تغيير الحساب";
                        case Word.disk: return "القيادة";
                        case Word.cloud: return "سحابة";
                        case Word.best_distance: return "أفضل مسافة";
                        case Word.last_visit: return "الزيارة الأخيرة";
                        case Word.name: return "الاسم الأول";
                        case Word.player_info: return "معلومات اللاعب";
                        case Word.enter_your_name: return "أدخل اسمك ،";
                        case Word.enter_new_name: return "أدخل اسمًا جديدًا ،";
                        case Word.pay: return "للدفع";
                        case Word.ok: return "حسنًا";
                        case Word.new_task_after: return "مهمة جديدة من خلال ،";
                        case Word.collect_gems: return "اجمع الجواهر";
                        case Word.deal_damage: return "التعامل مع الضرر";
                        case Word.kill_monsters: return "اقتل الوحوش";
                        case Word.kill_zombies: return "اقتل الزومبي";
                        case Word.reward: return "مكافأة";
                        case Word.privacy_policy: return "سياسة الخصوصية";
                        case Word.network_require: return "مطلوب الإنترنت";
                        case Word.inventory: return "المخزون";

                        case Word.daily: return "اليومي";
                        case Word.weekly: return "أسبوعي";
                        case Word.you_got: return "أنت حصلت";
                        case Word.promo_code: return "رمز ترويجي";
                        case Word.the_promo_code_is_incorrect_or_used: return "الرمز الترويجي غير صحيح أو مستخدم";
                        case Word.fuel: return "وقود";


                        default:
                            throw new NotImplementedException("Word don't exist!");
                    }

                case SystemLanguage.Danish:
                    switch (word)
                    {
                        case Word.ads: return "Annoncer";
                        case Word.brake: return "Bremse";
                        case Word.buy: return "Køb";
                        case Word.capacity: return "Kapacitet";
                        case Word.cars: return "Maskiner";
                        case Word.continue_for: return "Fortsæt til";
                        case Word.credits: return "Attributliste";
                        case Word.damage: return "Skade";
                        case Word.destroy: return "Ødelæggelse";
                        case Word.distance: return "Afstand";
                        case Word.fire: return "At skyde";
                        case Word.full: return "Fuld";
                        case Word.game_over: return "Spillet er forbi";
                        case Word.health: return "Styrke";
                        case Word.music: return "Musik";
                        case Word.pause: return "Pause";
                        case Word.play: return "Leg";
                        case Word.quit: return "Gå ud";
                        case Word.select: return "Vælg";
                        case Word.selected: return "Valgt";
                        case Word.settings: return "Indstillinger";
                        case Word.sfx: return "Lyde";
                        case Word.shop: return "Butik";
                        case Word.special: return "Specielle";
                        case Word.tasks: return "Opgaver";
                        case Word.total: return "I alt";
                        case Word.credits_text: 
                            return "Ikon lavet af Vectors Market fra www.flaticon.com\n3D: www.cgtrader.com\n\nSkabere: NikitaLnc og DoraLnc";

                        case Word.switch_account: return "Skift konto";
                        case Word.disk: return "Disk";
                        case Word.cloud: return "Sky";
                        case Word.best_distance: return "Bedste afstand";
                        case Word.last_visit: return "Sidste besøg";
                        case Word.name: return "Fornavn";
                        case Word.player_info: return "Spillerinformation";
                        case Word.enter_your_name: return "Indtast dit navn";
                        case Word.enter_new_name: return "Indtast et nyt navn";
                        case Word.pay: return "At betale";
                        case Word.ok: return "ok";
                        case Word.new_task_after: return "Ny opgave igennem";
                        case Word.collect_gems: return "Saml ædelstene";
                        case Word.deal_damage: return "Håndteringsskader";
                        case Word.kill_monsters: return "Dræb monstre";
                        case Word.kill_zombies: return "Dræb zombierne";
                        case Word.reward: return "Prisen";
                        case Word.privacy_policy: return "Politik til beskyttelse af personlige oplysninger";
                        case Word.network_require: return "Internet kræves";
                        case Word.inventory: return "Beholdning";

                        case Word.daily: return "Daglige";
                        case Word.weekly: return "Ugentlig";
                        case Word.you_got: return "Du har";
                        case Word.promo_code: return "Tilbudskode";
                        case Word.the_promo_code_is_incorrect_or_used: return "Promo-koden er forkert eller brugt";
                        case Word.fuel: return "Brændstof";


                        default:
                            throw new NotImplementedException("Word don't exist!");
                    }

                case SystemLanguage.Bulgarian:
                    switch (word)
                    {
                        case Word.ads: return "Реклами";
                        case Word.brake: return "Спирачка";
                        case Word.buy: return "Да се ​​купи";
                        case Word.capacity: return "Капацитет";
                        case Word.cars: return "Машини";
                        case Word.continue_for: return "Продължете за";
                        case Word.credits: return "Списък с атрибути";
                        case Word.damage: return "Щети";
                        case Word.destroy: return "Унищожение";
                        case Word.distance: return "Разстояние";
                        case Word.fire: return "Да стреля";
                        case Word.full: return "Пълен размер";
                        case Word.game_over: return "Играта свърши";
                        case Word.health: return "Сила";
                        case Word.music: return "Музика";
                        case Word.pause: return "Пауза";
                        case Word.play: return "Игра";
                        case Word.quit: return "Излезте";
                        case Word.select: return "Изберете";
                        case Word.selected: return "Подбран";
                        case Word.settings: return "Настройки";
                        case Word.sfx: return "Звуци";
                        case Word.shop: return "Магазин";
                        case Word.special: return "Специални";
                        case Word.tasks: return "Задания";
                        case Word.total: return "Общо";
                        case Word.credits_text:
                            return "Икона, направена от Vectors Market от www.flaticon.com\n3D: www.cgtrader.com\n\nСъздатели: NikitaLnc и DoraLnc";

                        case Word.switch_account: return "Промяна на акаунта";
                        case Word.disk: return "Диск";
                        case Word.cloud: return "Облак";
                        case Word.best_distance: return "Най-добро разстояние";
                        case Word.last_visit: return "Последно посещение";
                        case Word.name: return "Име";
                        case Word.player_info: return "Информация за играча";
                        case Word.enter_your_name: return "Въведете името си";
                        case Word.enter_new_name: return "Въведете ново име";
                        case Word.pay: return "Да плаща";
                        case Word.ok: return "ОК";
                        case Word.new_task_after: return "Нова задача чрез";
                        case Word.collect_gems: return "Събирайте скъпоценни камъни";
                        case Word.deal_damage: return "Отстраняване на щети";
                        case Word.kill_monsters: return "Убийте чудовища";
                        case Word.kill_zombies: return "Убийте зомбитата";
                        case Word.reward: return "Наградата";
                        case Word.privacy_policy: return "Политика за поверителност";
                        case Word.network_require: return "Изисква се интернет";
                        case Word.inventory: return "Склад";

                        case Word.daily: return "Дневно";
                        case Word.weekly: return "Седмично";
                        case Word.you_got: return "Ти взе";
                        case Word.promo_code: return "Промо код";
                        case Word.the_promo_code_is_incorrect_or_used: return "Промо кодът е неправилен или използван";
                        case Word.fuel: return "Гориво";


                        default:
                            throw new NotImplementedException("Word don't exist!");
                    }

                case SystemLanguage.Norwegian:
                    switch (word)
                    {
                        case Word.ads: return "Annonser";
                        case Word.brake: return "Brems";
                        case Word.buy: return "Kjøp";
                        case Word.capacity: return "Kapasitet";
                        case Word.cars: return "Maskiner";
                        case Word.continue_for: return "Fortsett for";
                        case Word.credits: return "Attributtliste";
                        case Word.damage: return "Skade";
                        case Word.destroy: return "Ødeleggelse";
                        case Word.distance: return "Avstand";
                        case Word.fire: return "Å skyte";
                        case Word.full: return "Full";
                        case Word.game_over: return "Spillet er over";
                        case Word.health: return "Styrke";
                        case Word.music: return "Musikk";
                        case Word.pause: return "Pause";
                        case Word.play: return "Play";
                        case Word.quit: return "Gå ut";
                        case Word.select: return "Velg";
                        case Word.selected: return "Valgt";
                        case Word.settings: return "Innstillinger";
                        case Word.sfx: return "Lyder";
                        case Word.shop: return "Butikk";
                        case Word.special: return "Spesielle";
                        case Word.tasks: return "Oppdrag";
                        case Word.total: return "Total";
                        case Word.credits_text:
                            return "Ikon laget av Vectors Market fra www.flaticon.com\n3D: www.cgtrader.com\n\nSkapere: NikitaLnc og DoraLnc";

                        case Word.switch_account: return "Bytt konto";
                        case Word.disk: return "Disk";
                        case Word.cloud: return "Sky";
                        case Word.best_distance: return "Beste avstand";
                        case Word.last_visit: return "Siste besøk";
                        case Word.name: return "Fornavn";
                        case Word.player_info: return "Spillerinformasjon";
                        case Word.enter_your_name: return "Skriv inn navnet ditt";
                        case Word.enter_new_name: return "Skriv inn et nytt navn";
                        case Word.pay: return "Å betale";
                        case Word.ok: return "ok";
                        case Word.new_task_after: return "Ny oppgave gjennom";
                        case Word.collect_gems: return "Samle perler";
                        case Word.deal_damage: return "Håndteringsskader";
                        case Word.kill_monsters: return "Drep monstre";
                        case Word.kill_zombies: return "Drep zombiene";
                        case Word.reward: return "Tildelingen";
                        case Word.privacy_policy: return "Personvern";
                        case Word.network_require: return "Internett kreves";
                        case Word.inventory: return "Inventar";

                        case Word.daily: return "Daglig";
                        case Word.weekly: return "Ukentlig";
                        case Word.you_got: return "Du har";
                        case Word.promo_code: return "Rabattkode";
                        case Word.the_promo_code_is_incorrect_or_used: return "Kampanjekoden er feil eller brukt";
                        case Word.fuel: return "Brensel";


                        default:
                            throw new NotImplementedException("Word don't exist!");
                    }

                case SystemLanguage.Lithuanian:
                    switch (word)
                    {
                        case Word.ads: return "Skelbimas";
                        case Word.brake: return "Stabdyti";
                        case Word.buy: return "Pirkite";
                        case Word.capacity: return "Talpa";
                        case Word.cars: return "Automobiliai";
                        case Word.continue_for: return "Tęskite toliau";
                        case Word.credits: return "Atributų sąrašas";
                        case Word.damage: return "Žala";
                        case Word.destroy: return "Sunaikinimas";
                        case Word.distance: return "Atstumas";
                        case Word.fire: return "Šaudyti";
                        case Word.full: return "Pilna";
                        case Word.game_over: return "Žaidimas baigėsi";
                        case Word.health: return "Stiprumas";
                        case Word.music: return "Muzika";
                        case Word.pause: return "Pauzė";
                        case Word.play: return "Žaisk";
                        case Word.quit: return "Išeik";
                        case Word.select: return "Pasirinkite";
                        case Word.selected: return "Pasirinkta";
                        case Word.settings: return "Nustatymai";
                        case Word.sfx: return "Garsai";
                        case Word.shop: return "Parduotuvė";
                        case Word.special: return "Ypatinga";
                        case Word.tasks: return "Uždaviniai";
                        case Word.total: return "Iš viso";
                        case Word.credits_text:
                            return "Ikona, kurią sukūrė„ Vectors Market “iš www.flaticon.com\n3D: www.cgtrader.com\n\nKūrėjai: „NikitaLnc“ ir „DoraLnc“";

                        case Word.switch_account: return "Pakeisti sąskaitą";
                        case Word.disk: return "Važiuok";
                        case Word.cloud: return "Debesis";
                        case Word.best_distance: return "Geriausias atstumas";
                        case Word.last_visit: return "Paskutinis vizitas";
                        case Word.name: return "Vardas";
                        case Word.player_info: return "Informacija apie žaidėją";
                        case Word.enter_your_name: return "Įveskite savo vardą";
                        case Word.enter_new_name: return "Įveskite naują vardą";
                        case Word.pay: return "Mokėti";
                        case Word.ok: return "Gerai";
                        case Word.new_task_after: return "Nauja užduotis";
                        case Word.collect_gems: return "Surinkite brangakmenius";
                        case Word.deal_damage: return "Žalos atlyginimas";
                        case Word.kill_monsters: return "Nužudyk monstrus";
                        case Word.kill_zombies: return "Nužudyk zombius";
                        case Word.reward: return "Atlygis";
                        case Word.privacy_policy: return "Privatumo politika";
                        case Word.network_require: return "Reikalingas internetas";
                        case Word.inventory: return "Inventorius";

                        case Word.daily: return "Kasdien";
                        case Word.weekly: return "Kas savaitę";
                        case Word.you_got: return "Tu turi";
                        case Word.promo_code: return "Reklamos kredito kodas";
                        case Word.the_promo_code_is_incorrect_or_used: return "Reklamos kredito kodas neteisingas arba naudojamas";
                        case Word.fuel: return "Degalai";


                        default:
                            throw new NotImplementedException("Word don't exist!");
                    }

                case SystemLanguage.Vietnamese:
                    switch (word)
                    {
                        case Word.ads: return "Quảng cáo";
                        case Word.brake: return "Phanh";
                        case Word.buy: return "Mua";
                        case Word.capacity: return "Công suất";
                        case Word.cars: return "Ô tô";
                        case Word.continue_for: return "Tiếp tục cho";
                        case Word.credits: return "Danh sách thuộc tính";
                        case Word.damage: return "Thiệt hại";
                        case Word.destroy: return "Phá hủy";
                        case Word.distance: return "Khoảng cách";
                        case Word.fire: return "Bắn";
                        case Word.full: return "Đầy đủ";
                        case Word.game_over: return "Trò chơi kết thúc";
                        case Word.health: return "Sức mạnh";
                        case Word.music: return "Âm nhạc";
                        case Word.pause: return "Tạm dừng";
                        case Word.play: return "Chơi";
                        case Word.quit: return "Đi ra ngoài";
                        case Word.select: return "Chọn";
                        case Word.selected: return "Đã chọn";
                        case Word.settings: return "Cài đặt";
                        case Word.sfx: return "Âm thanh";
                        case Word.shop: return "Cửa hàng";
                        case Word.special: return "Đặc biệt";
                        case Word.tasks: return "Nhiệm vụ";
                        case Word.total: return "Tổng cộng";
                        case Word.credits_text:
                            return "Biểu tượng được tạo bởi vectơ thị trường từ www.flaticon.com\n3D: www.cgtrader.com\n\nNgười tạo: NikitaLnc và DoraLnc";

                        case Word.switch_account: return "Thay đổi tài khoản";
                        case Word.disk: return "Lái xe";
                        case Word.cloud: return "Đám mây";
                        case Word.best_distance: return "Khoảng cách tốt nhất";
                        case Word.last_visit: return "Chuyến thăm cuối cùng";
                        case Word.name: return "Tên";
                        case Word.player_info: return "Thông tin người chơi";
                        case Word.enter_your_name: return "Nhập tên của bạn";
                        case Word.enter_new_name: return "Nhập tên mới";
                        case Word.pay: return "Thanh toán";
                        case Word.ok: return "Được rồi";
                        case Word.new_task_after: return "Nhiệm vụ mới thông qua";
                        case Word.collect_gems: return "Thu thập đá quý";
                        case Word.deal_damage: return "Xử lý thiệt hại";
                        case Word.kill_monsters: return "Tiêu diệt quái vật";
                        case Word.kill_zombies: return "Tiêu diệt zombie";
                        case Word.reward: return "Phần thưởng";
                        case Word.privacy_policy: return "Chính sách bảo mật";
                        case Word.network_require: return "Yêu cầu Internet";
                        case Word.inventory: return "Hàng tồn kho";

                        case Word.daily: return "Hằng ngày";
                        case Word.weekly: return "Hàng tuần";
                        case Word.you_got: return "Bạn có";
                        case Word.promo_code: return "Mã khuyến mại";
                        case Word.the_promo_code_is_incorrect_or_used: return "Mã khuyến mãi không chính xác hoặc được sử dụng";
                        case Word.fuel: return "Nhiên liệu";


                        default:
                            throw new NotImplementedException("Word don't exist!");
                    }


                default:
                    throw new NotImplementedException("Language don't exist!");
            }
        }
    
        public static SystemLanguage[] SupportedLanguages
        {
            get
            {
                SystemLanguage[] arr = new SystemLanguage[25];
                arr[0] = SystemLanguage.English;
                arr[1] = SystemLanguage.Russian;
                arr[2] = SystemLanguage.Romanian;
                arr[3] = SystemLanguage.Turkish;
                arr[4] = SystemLanguage.Spanish;
                arr[5] = SystemLanguage.Portuguese;
                arr[6] = SystemLanguage.French;
                arr[7] = SystemLanguage.German;
                arr[8] = SystemLanguage.Italian;
                arr[9] = SystemLanguage.Ukrainian;
                arr[10] = SystemLanguage.Polish;
                arr[11] = SystemLanguage.Swedish;
                arr[12] = SystemLanguage.ChineseSimplified;
                arr[13] = SystemLanguage.Belarusian;
                arr[14] = SystemLanguage.Czech;
                arr[15] = SystemLanguage.Indonesian;
                arr[16] = SystemLanguage.Greek;
                arr[17] = SystemLanguage.Japanese;
                arr[18] = SystemLanguage.Korean;
                arr[19] = SystemLanguage.Arabic;
                arr[20] = SystemLanguage.Danish;
                arr[21] = SystemLanguage.Bulgarian;
                arr[22] = SystemLanguage.Norwegian;
                arr[23] = SystemLanguage.Lithuanian;
                arr[24] = SystemLanguage.Vietnamese;


                return arr;
            }
        }
    }


    public enum Word
    {
        distance, destroy, special, total, music, sfx, quit, brake,
        fire, pause, continue_for, game_over, shop, cars, play, settings,
        tasks, ads, buy, select, selected, health, damage, capacity, 
        credits, full, credits_text, switch_account, disk, cloud, 
        best_distance, last_visit, name, player_info, enter_your_name,
        enter_new_name, pay, ok, new_task_after, collect_gems, deal_damage,
        kill_monsters, kill_zombies, reward, privacy_policy, network_require, inventory,
        daily, weekly, you_got, promo_code, the_promo_code_is_incorrect_or_used, fuel,
    }
}
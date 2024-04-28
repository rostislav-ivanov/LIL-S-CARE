using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    internal class SectionDescriptionConfiguration : IEntityTypeConfiguration<SectionDescription>
    {
        private readonly IEnumerable<SectionDescription> descriptions =
        [
            new ()
            {
                Id = 1,
                DescriptionEN = "Gentle, all-natural and handmade dry deodorant. Suitable for daily use.\r\n \r\nNo perfume and no essential oils.\r\n \r\nIn a new hard version for easier application and direct application.\r\n \r\nOr you can use an old deodorant stick pack to melt the bar for convenient daily use.\r\n \r\nCut the bar into pieces and put them in a stick pack. And microwave on low and for short intervals until the block melts. Let it cool and harden and it's done!\r\n \r\nIf you don't have a microwave, you can melt it in a water bath in a stick. Wrap the stick fitting tightly with stretch film to prevent water from entering the fitting and the product.\r\n \r\n100% natural\r\n10% from Bulgaria\r\n78.4% organic",
                DescriptionBG = "Нежен, изцяло натурален и ръчно изработен сух дезодорант. Подходящ за ежедневна употреба.\r\n \r\nБез парфюм и без етерични масла.\r\n \r\nВ нов твърд вариант за по-лесна употеба и нансяне дирктно.\r\n \r\nИли може да използвате стара опаковка от стик дезодорант, за да разтопите блокчето за удобна ежедневна употреба.\r\n \r\nСрежете блокчето на парченца и ги сложете в стик опаковка. Иползвайте микровълнова фурна на ниска температура и за картки интервали докато блокечето се разтопи. Оставете да изстине и стегне и готово!\r\n \r\nАко не разполагате с микровълнова фурна, може да го разтопите на водна баня в стик. Увийете плътно стик опковката със стреч фолио, за да не влиза вода в опковката и при продукта.\r\n \r\n100% натурален\r\n10 % от България\r\n78.4% био",
                DescriptionRO = "Deodorant uscat blând, natural și realizat manual. Potrivit pentru utilizarea zilnică.\r\n \r\nFără parfum și fără uleiuri esențiale.\r\n \r\nÎntr-o nouă versiune hard pentru aplicare mai ușoară și aplicare directă.\r\n \r\nSau puteți utiliza un pachet vechi de deodorant pentru a topi batonul pentru o utilizare zilnică convenabilă.\r\n \r\nTăiați batonul în bucăți și puneți-le într-un pachet de bețișoare. Și puneți la microunde la foc mic și pentru intervale scurte până când blocul se topește. Se lasa sa se raceasca si sa se intareasca si gata!\r\n \r\nDaca nu ai cuptor cu microunde il poti topi in baie de apa intr-un bat. Înveliți strâns garnitura cu folie extensibilă pentru a preveni intrarea apei în fiting și în produs.\r\n \r\n100% natural\r\n10% din Bulgaria\r\n78,4% organic"
            },
            new ()
            {
                Id = 2,
                DescriptionEN = "Dry ingredients such as organic tapioca keep the underarms dry during the day.\r\nVitamin E has an antioxidant effect.\r\nCoconut oil, shea butter and beeswax.",
                DescriptionBG = "Сухите съставки като био тапиока поддържат подмишниците сухи през деня.\r\nВитамин Е има антиоксидантен ефект.\r\nКокосово масло, масло от ший (карите) и пчелен восък.",
                DescriptionRO = "Ingredientele uscate precum tapioca organică mențin axile uscate în timpul zilei.\r\nVitamina E are efect antioxidant.\r\nUleiul de cocos, untul de shea și ceara de albine."
            },
            new ()
            {
                Id = 3,
                DescriptionEN = "Take the stick out of the box and apply to your underarms.\r\n \r\nOr gently melt it into a deodorant stick pack for easier and more convenient daily use.\r\n \r\nYou can reuse an old pack from a previous deodorant.\r\n r\n \r\nFor external use only. Keep out of reach of children. Do not use if allergic to any of the ingredients. Store tightly closed in a dry place protected from direct sunlight.",
                DescriptionBG = "Вземете блокчето от кутийката и намажете подмишничите.\r\n \r\nИли внимателно го разтопете в опаковка за стик дезодорант за по-лесна и удобна ежедневна употреба.\r\n \r\nМоже да преизползвате стара опаковка от предишен дезодорант.\r\n \r\nСамо за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте добре затворено на сухо място, защитено от пряка слънчева светлина.",
                DescriptionRO = "Scoateți batonul din cutie și aplicați-l pe axile.\r\n \r\nSau topește-l ușor într-un pachet de deodorant pentru o utilizare zilnică mai ușoară și mai convenabilă.\r\n \r\nPuteți reutiliza un pachet vechi. dintr-un deodorant anterior.\r\n r\n \r\nNumai pentru uz extern. A nu se lăsa la îndemâna copiilor. A nu se utiliza dacă este alergic la oricare dintre ingrediente. A se pastra bine inchis intr-un loc uscat ferit de lumina directa a soarelui."
            },
            new ()
            {
                Id = 4,
                DescriptionEN = "Once a shipping address or Econt or Speedy courier office is specified in the address fields when ordering, products are carefully packed in a recycled cardboard box and paper padding for a seal and sent by inspected delivery.",
                DescriptionBG = "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед.",
                DescriptionRO = "Odată ce o adresă de expediere sau un birou de curierat Econt sau Speedy este specificată în câmpurile de adresă în momentul comenzii, produsele sunt ambalate cu grijă într-o cutie de carton reciclat și căptușeală de hârtie pentru sigilare și trimise prin livrare inspectată."
            },
            new ()
            {
                Id = 5,
                DescriptionEN = "Cocos Nucifera (Coconut) Oil*, Tapioca Starch*, Butyrospermum Parkii (Shea) Butter*, Cera Alba (Beeswax), Glyceryl Stearate, Sodium Bicarbonate, Tocopherol (Vit E), Helianthus Annuus (Sunflower) Seed Oil* \r\n*Bio",
                DescriptionBG = "Cocos Nucifera (Coconut) Oil*, Tapioca Starch*, Butyrospermum Parkii (Shea) Butter*, Cera Alba (Beeswax), Glyceryl Stearate, Sodium Bicarbonate, Tocopherol (Vit E), Helianthus Annuus (Sunflower) Seed Oil* \r\n*Bio",
                DescriptionRO = "Cocos Nucifera (Coconut) Oil*, Tapioca Starch*, Butyrospermum Parkii (Shea) Butter*, Cera Alba (Beeswax), Glyceryl Stearate, Sodium Bicarbonate, Tocopherol (Vit E), Helianthus Annuus (Sunflower) Seed Oil* \r\n*Bio"
            },
            new ()
            {
                Id = 6,
                DescriptionEN = "An all-natural and hand-crafted lip balm that feels cozy and soft. Designed to be gentle and protective.\r\n \r\nOrganic Cocoa Butter\r\nNatural what a fragrance\r\nCombined with natural vanilla butter\r\nBeeswax\r\n \r\nIn two variants:\r \nLight and shiny transparent color\r\nCompletely colorless\r\n \r\nEnriched with vitamin E and organic jojoba oil.\r\n \r\n100% natural\r\n49% from Bulgaria\r\n41% bio",
                DescriptionBG = "Изцяло натурален и ръчно изработен балсам за устни, който носи усещане за уют и мекота. Създаден да е нежен и защитаващ.\r\n \r\nБио какаово масло\r\nЕстствен каков аромат\r\nКомбиниран с натурално масло от ванилия\r\nПчелен восък\r\n \r\nВ два варианта:\r\nЛек и блестящ прозрачен цвят\r\nИзцяло безцветен\r\n \r\nОбогатен с витамин Е и био масло от жожоба.\r\n \r\n100% натурален\r\n49% от България\r\n41% био",
                DescriptionRO = "Un balsam de buze natural și realizat manual, care se simte confortabil și moale. Conceput să fie blând și protector.\r\n \r\nUnt de cacao organic\r\nNatural ce parfum\r\nCombinat cu unt natural de vanilie\r\nCeară de albine\r\n \r\nÎn două variante:\r\nCuloare transparentă deschisă și strălucitoare\r\nComplet incolor\r\n \r\nÎmbogățit cu vitamina E și ulei organic de jojoba.\r\n \r\n100% natural\r\n49% din Bulgaria\r\n41% bio"
            },
            new ()
            {
                Id = 7,
                DescriptionEN = "Cocoa butter* gives a light and natural chocolate aroma and protects the lips.\r\n \r\nJojoba oil* nourishes them.\r\n \r\nBeeswax* protects the lips, makes the balm last both on the lips and in the tube not to end quickly. Gives a feeling of cushion and softness on the lips.\r\n \r\nVitamin E - a natural antioxidant that protects against harmful environmental influences.\r\n \r\n*Bio 41% of the composition",
                DescriptionBG = "Какаовото масло* придава лек и естествен шоколадов аромат и предпазва устните.\r\n \r\nМаслото от жожоба* ги подхранва.\r\n \r\nПчелния восък* защитава устните, прави балсама траен както върху устните така и в тубичката да не свършва бързо. Придава усещане за възглванича и мекота върху устните.\r\n \r\nВитамин Е - натурален антиоксидант, който защитава от вредните влияния от околната среда.\r\n \r\n*Био 41% от състава",
                DescriptionRO = "Untul de cacao* confera o aroma usoara si naturala de ciocolata si protejeaza buzele.\r\n \r\nUleiul de jojoba* le hraneste.\r\n \r\nCera de albine* protejeaza buzele, face ca balsamul sa reziste atat pe buze cat si în tub să nu se termine repede. Oferă o senzație de perniță și catifelare pe buze.\r\n \r\nVitamina E - un antioxidant natural care protejează împotriva influențelor nocive ale mediului.\r\n \r\n*Bio 41% din compoziție"
            },
            new ()
            {
                Id = 8,
                DescriptionEN = "All natural, you can use it whenever you want to nourish and protect your lips or just give them a slight shine to complete your look.\r\n \r\nFor external use only. Keep out of reach of children. Do not use if allergic to any of the ingredients. Store with the cap closed, in a dry place and protected from direct sunlight.",
                DescriptionBG = "Изцяло натурален, може да използвате винаги когато искате да подхраните и защитите устните си или просто да им придадете лек блясък за завършен вид на визията си.\r\n \r\nСамо за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте със затворено капаче, на сухо място и защитено от пряка слънчева светлина.",
                DescriptionRO = "În totalitate naturală, îl poți folosi oricând vrei să-ți hrănești și să-ți protejezi buzele sau doar să le dai o ușoară strălucire pentru a-ți completa aspectul.\r\n \r\nNumai pentru uz extern. A nu se lăsa la îndemâna copiilor. A nu se utiliza dacă este alergic la oricare dintre ingrediente. A se pastra cu capacul inchis, la loc uscat si ferit de lumina directa a soarelui."
            },
            new ()
            {
                Id = 9,
                DescriptionEN = "Once a shipping address or Econt or Speedy courier office is specified in the address fields when ordering, products are carefully packed in a recycled cardboard box and paper padding for a seal and sent by inspected delivery.",
                DescriptionBG = "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед.",
                DescriptionRO = "Odată ce o adresă de expediere sau un birou de curierat Econt sau Speedy este specificată în câmpurile de adresă în momentul comenzii, produsele sunt ambalate cu grijă într-o cutie de carton reciclat și căptușeală de hârtie pentru sigilare și trimise prin livrare inspectată."
            },
            new ()
            {
                Id = 10,
                DescriptionEN = "Apricot Kernel Oil (масло от кайсиеви ядки), Theobroma Cacao Seed Butter (какаово масло)*, Copernicia Cerifera Cera (Карнаубски восък, веган)*, Simmondsia Chinensis Seed Oil (масло от жожоба)*, Helianthus Annuus Seed Oil (слънчогледово масло), Vanilla Planifolia Fruit Extract (екстракт от шушулки ванилия), Mica**, CI 77491 (Iron Oxide)**, Tocopherol (витамин E).\r\n*Био 49% **Минерални пигменти 1%",
                DescriptionBG = "Apricot Kernel Oil (масло от кайсиеви ядки), Theobroma Cacao Seed Butter (какаово масло)*, Copernicia Cerifera Cera (Карнаубски восък, веган)*, Simmondsia Chinensis Seed Oil (масло от жожоба)*, Helianthus Annuus Seed Oil (слънчогледово масло), Vanilla Planifolia Fruit Extract (екстракт от шушулки ванилия), Mica**, CI 77491 (Iron Oxide)**, Tocopherol (витамин E).\r\n*Био 49% **Минерални пигменти 1%",
                DescriptionRO = "Apricot Kernel Oil (масло от кайсиеви ядки), Theobroma Cacao Seed Butter (какаово масло)*, Copernicia Cerifera Cera (Карнаубски восък, веган)*, Simmondsia Chinensis Seed Oil (масло от жожоба)*, Helianthus Annuus Seed Oil (слънчогледово масло), Vanilla Planifolia Fruit Extract (екстракт от шушулки ванилия), Mica**, CI 77491 (Iron Oxide)**, Tocopherol (витамин E).\r\n*Био 49% **Минерални пигменти 1%"
            },
            new ()
            {
                Id = 11,
                DescriptionEN = "DESCRIPTION",
                DescriptionBG = "ОПИСАНИЕ",
                DescriptionRO = "DESCRIERE"
            },
            new ()
            {
                Id = 12,
                DescriptionEN = "Bulgarian cold-pressed rosehip oil* - a natural source of vitamin A, nourishes and stimulates skin regeneration.\r\n \r\nRosehip extract - botanical glycerine extract, which in this cream is a wonderful combination with rosehip oil.\r \n \r\nShea Butter* - The lightest and lowest comedogenic rating (0-2) of all solid oils. This means it has a low chance of clogging pores on a scale of 0 to 5.\r\n \r\nVitamin B3 - Niacinamide - An antioxidant that evens out the complexion, regulates sebum, aids hydration and smoothes fine lines. Naistirna sounds incredible, a is doaxrno.\r\n \r\nVitamin E - has an effective and natural antioxidant effect: it forgets aging by helping to restore the skin and protects it from free radicals and environmental damage.\r\n \r\nVegetable glycerin and hyaluronic - humectants - attract water and hydrate the skin. Concentration is key! Too much of these can dry out the skin by starting to pull moisture from the deeper layers of the skin when the air is dry. The balance between water and humectants in the product is important.\r\n \r\n*Bio",
                DescriptionBG = "Българско студено пресовано масло от шипка* - натурален източник на витамин А, подхранва и стимулура регенерирнето на кожата.\r\n \r\nЕкстракт от шипка - ботанически глицернов екстракт, който в този крем е чъдесна комбинация с маслото от шипка.\r\n \r\nМасло от ший* - Най-лекото и с най-нисък комедогенен рейтинг (0-2) от всички твърди масла. Това означава, че има ниска вероятност да запуши порите като скалата е от 0 до 5.\r\n \r\nВитамин B3 - ниацинамид - антиоксидант, който изравнява тена, регулира себума, помага худратацията и изглажда финни бръчки. Наистирна звучи неверояно, a е доакзрно.\r\n \r\nВитамин Е - има ефективо и естетвено антиоксидантно действие:  забвя стареенето като помага за възстановяването на кожата и я предпазва от свободните радикали и вредите от околната среда.\r\n \r\nРастителни глицерин и хиалурон - хумектанти - привличат водата и хидратират кожата. Ключова е концентрацията! Твърде много от тях могат да изсушат кожата, като започнат да издърпват влагата от по-дълбоките слоеве на кожата, когато въздуха е сух. Важен е баланса между вода и хумектанти в продукта.\r\n \r\n*Био",
                DescriptionRO = "Uleiul bulgar de macese presat la rece* - o sursa naturala de vitamina A, hraneste si stimuleaza regenerarea pielii.\r\n \r\nExtract de macese - extract de glicerina botanica, care in aceasta crema este o combinatie minunata cu uleiul de macese.\r\n \r\nUnt de Shea* - Cel mai ușor și cel mai scăzut rating comedogen (0-2) dintre toate uleiurile solide. Aceasta înseamnă că are o șansă scăzută de a înfunda porii pe o scară de la 0 la 5.\r\n \r\nVitamina B3 - Niacinamidă - Un antioxidant care uniformizează tenul, reglează sebumul, ajută la hidratare și netezește liniile fine. Naistirna sună incredibil, a is doaxrno.\r\n \r\nVitamina E - are un efect antioxidant eficient și natural: uită de îmbătrânire ajutând la refacerea pielii și o protejează de radicalii liberi și daunele mediului.\r\n \r\nGlicerina vegetală și hialuronicul - umectanți - atrag apa și hidratează pielea. Concentrarea este cheia! Prea multe dintre acestea pot usca pielea, pornind să atragă umezeala din straturile mai profunde ale pielii atunci când aerul este uscat. Echilibrul dintre apă și umectanți din produs este important.\r\n \r\n*Bio"
            },
            new ()
            {
                Id = 13,
                DescriptionEN = "Apply to dry or damp skin. A small amount is enough for the whole face and neck. Use 1-2 times daily as needed and skin dryness.\r\n \r\nCan be applied to damp skin, such as after shower and gel wash to lock in hydration.\r\n \r\nOr to dry skin , to protect it.\r\n \r\nApply to well-cleansed skin with clean hands. For external use only. Keep out of reach of children. Do not use if allergic to any of the ingredients. Store tightly closed, in a dry place, protected from direct sunlight.",
                DescriptionBG = "Нанесете върху суха или влажна кожа. Малко количество е достатъчно за цялото лице и шия. Използвайте 1-2 пъти дневно според необходимостта и сухотата на кожата.\r\n \r\nМоже да нансете върху влажна кожа, например след душ и измивен гел, за да заключите хидратацията.\r\n \r\nИли върхъ суха кожа, за да я защитите.\r\n \r\nНанасяйте върху добре почистена кожа с чисти ръце. Само за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте добре затворено, на сухо място, защитено от пряка слънчева светлина.",
                DescriptionRO = "Aplicați pe pielea uscată sau umedă. O cantitate mică este suficientă pentru toată fața și gâtul. Utilizați de 1-2 ori pe zi după cum este necesar și pielea uscată.\r\n \r\nPoate fi aplicat pe pielea umedă, cum ar fi după duș și spălare cu gel pentru a menține hidratarea.\r\n \r\nSau pe pielea uscată , pentru a-l proteja.\r\n \r\nAplicați pe pielea bine curățată cu mâinile curate. Doar pentru uz extern. A nu se lăsa la îndemâna copiilor. A nu se utiliza dacă este alergic la oricare dintre ingrediente. A se pastra bine inchis, intr-un loc uscat, ferit de lumina directa a soarelui."
            },
            new ()
            {
                Id = 14,
                DescriptionEN = "Once a shipping address or Econt or Speedy courier office is specified in the address fields when ordering, products are carefully packed in a recycled cardboard box and paper padding for a seal and sent by inspected delivery.",
                DescriptionBG = "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед.",
                DescriptionRO = "Odată ce o adresă de expediere sau un birou de curierat Econt sau Speedy este specificată în câmpurile de adresă în momentul comenzii, produsele sunt ambalate cu grijă într-o cutie de carton reciclat și căptușeală de hârtie pentru sigilare și trimise prin livrare inspectată."
            },
            new ()
            {
                Id = 15,
                DescriptionEN = "Aqua (Water), Rosa Canina Seed Oil* (rosehip oil, 10%), Butyrospermum Parkii Butter* (shea butter), Glycerin (glycerin), Rosa Canina Fruit Extract (rosehip extract), Niacinamide (vitamin B3 ), Cetearyl Olivate, Sorbitan Olivate (emulsifiers), Sodium Hyaluronate (hyaluronic acid), Tocopherol (vitamin E), Helianthus Annuus (Sunflower) Seed Oil*, Sodium Benzoate, Potassium Sorbate (preservatives), Lactic Acid (lactic acid, AHA, adjusts the pH of the product).\r\n*Bio",
                DescriptionBG = "Aqua (apă), ulei de semințe de Rosa Canina* (ulei de măceș, 10%), unt de Butyrospermum Parkii* (unt de shea), glicerină (glicerină), extract de fructe Rosa Canina (extract de măceș), niacinamidă (vitamina B3), olivat de cetearil, Olivat de sorbitan (emulgatori), hialuronat de sodiu (acid hialuronic), tocoferol (vitamina E), ulei de semințe de Helianthus Annuus (floarea-soarelui)*, benzoat de sodiu, sorbat de potasiu (conservanți), acid lactic (acid lactic, AHA, reglează pH-ul) produs).\r\n*Bio",
                DescriptionRO = "Aqua (Вода), Rosa Canina Seed Oil* (масло от шипка, 10%) , Butyrospermum Parkii Butter* (масло от ший/карите), Glycerin (глицерин), Rosa Canina Fruit Extract (екстракт от шипка), Niacinamide (витамин B3), Cetearyl Olivate, Sorbitan Olivate (емулгатори), Sodium Hyaluronate (хиалуронова киселина), Tocopherol (витамин E), Helianthus Annuus (Слънчоглед) Seed Oil*, Sodium Benzoate, Potassium Sorbate (консерванти), Lactic Acid (млечна киселина, AHA, регулира pH на продукта).\r\n*Bio"
            },
            new ()
            {
                Id = 16,
                DescriptionEN = "Natural micellar water with two components. Shake before use to mix the two phases. It is ideal for the gentle removal of make-up at the end of the day.\r\n \r\nIt has a double action as a facial toner with green tea extract and vitamin E.\r\n \r\nPhase 1 is extremely gentle. It has a soothing and antioxidant effect thanks to green tea extract, squalene and panthenol (provitamin B3).\r\n \r\nPhase 2 is with organic jojoba oil and helps to dissolve makeup. Leaves the skin soft, nourished and protected.\r\n \r\nIn a convenient bottle with a popma for easy use.\r\n \r\n100% natural\r\n94% from Bulgaria",
                DescriptionBG = "Натурална мицеларна вода с два компонента. Разклатете преди употреба, за да се смесят двете фази. Идеална е за нежното отстраняване на грима в края на деня.\r\n \r\nИма двойно действие е като тоник за лице с екстракт от зелен чай и витамин Е.\r\n \r\nФаза 1 е изключително нежна. Има успокояващо и антиоксидантно действие благодарение на екстракта от зелен чай, сквален и пантенол (провитамин B3).\r\n \r\nФаза 2 е с био масло от жожоба и допринся за разтврянето на грима. Оставя кожата мека, подхранена и защитена.\r\n \r\nВ удобно шишенце с попма за лесно използване.\r\n \r\n100% натурална\r\n94% от България",
                DescriptionRO = "Apa micelara naturala cu doua componente. Agitați înainte de utilizare pentru a amesteca cele două faze. Este ideal pentru demachierea blândă la sfârșitul zilei.\r\n \r\nAre dublă acțiune ca tonic facial cu extract de ceai verde și vitamina E.\r\n \r\nFază 1 este extrem de blând. Are un efect calmant si antioxidant datorita extractului de ceai verde, squalenului si pantenolului (provitamina B3).\r\n \r\nFaza 2 este cu ulei de jojoba organic si ajuta la dizolvarea machiajului. Lasă pielea moale, hrănită și protejată.\r\n \r\nÎntr-o sticlă convenabilă cu popma pentru utilizare ușoară.\r\n \r\n100% natural\r\n94% din Bulgaria"
            },
            new ()
            {
                Id = 17,
                DescriptionEN = "Green tea extract - antioxidant and soothing action, helps against the appearance of acne\r\n \r\nBio Jojoba oil - helps to gently dissolve make-up and nourishes the skin\r\n \r\nVitamin E - antioxidant, soothes irritations , fights free radicals and slows skin aging\r\n \r\nPanthenol - provitamin B5 - with plant origin. Hydrates and nourishes\r\n \r\nGrapefruit essential oil - light citrus scent",
                DescriptionBG = "Екстракт от зелен чай - антиоксидантно и успокояващо действе, помага против появата на акне\r\n \r\nБио масло от Жожоба - помага за нежното разтваряне на грима и подхранва кожата\r\n \r\nВитамин Е - антиоксидант, успокоява раздразненията, бори се със свободните радикали и забавя стареенето на кожата\r\n \r\nПантенол - провитамин B5 - с растителен прозход. Хидратира и подхранва\r\n \r\nЕтерично масло грейпфрут - лек цитрусов аромат",
                DescriptionRO = "Extract de ceai verde - actiune antioxidanta si calmanta, ajuta impotriva aparitiei acneei\r\n \r\nUlei de jojoba Bio - ajuta la dizolvarea delicata a machiajului si hraneste pielea\r\n \r\nVitamina E - antioxidant, calmeaza iritatii, combate radicalii liberi si incetineste imbatranirea pielii\r\n \r\nPantenol - provitamina B5 - cu origine vegetala. Hidratează și hrănește\r\n \r\nUlei esențial de grapefruit - parfum ușor de citrice"
            },
            new ()
            {
                Id = 18,
                DescriptionEN = "Shake before use.\r\n \r\nCan be used whenever you want to gently remove makeup. Shake before use and soak a cotton pad. Gently press into skin to wet and begin to dissolve makeup. Then remove the makeup with light movements from the center of the face to the sides.\r\n \r\nFor external use only. Keep out of reach of children. Do not use if allergic to any of the ingredients. Store in a dry place away from direct sunlight.",
                DescriptionBG = "Разклаете преди употреба.\r\n \r\nМоже да използвате винаги, когато искате нежно да премахнете грима. Разклатете преди употреба и напоете памучно тампонче. Нежно притиснете към кожата, за да се намокри и да започне да разтваря грима. След това отстранете грима с леки движения от центъра на лицето към страните.\r\n \r\nСамо за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте на сухо място, защитено от пряка слънчева светлина.",
                DescriptionRO = "Agitați înainte de utilizare.\r\n \r\nPoate fi folosit oricând doriți să îndepărtați ușor machiajul. Agitați înainte de utilizare și înmuiați un tampon de bumbac. Apăsați ușor pielea pentru a uda și începe să dizolveți machiajul. Apoi indeparteaza machiajul cu miscari usoare din centrul fetei spre laterale.\r\n \r\nNumai pentru uz extern. A nu se lăsa la îndemâna copiilor. A nu se utiliza dacă este alergic la oricare dintre ingrediente. A se pastra intr-un loc uscat ferit de lumina directa a soarelui."
            },
            new ()
            {
                Id = 19,
                DescriptionEN = "Once a shipping address or Econt or Speedy courier office is specified in the address fields when ordering, products are carefully packed in a recycled cardboard box and paper padding for a seal and sent by inspected delivery.",
                DescriptionBG = "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед.",
                DescriptionRO = "Odată ce o adresă de expediere sau un birou de curierat Econt sau Speedy este specificată în câmpurile de adresă în momentul comenzii, produsele sunt ambalate cu grijă într-o cutie de carton reciclat și căptușeală de hârtie pentru sigilare și trimise prin livrare inspectată."
            },
            new ()
            {
                Id = 20,
                DescriptionEN = "Aqua, Vitis Vinifera (Grape) Seed Oil, Camellia Sinensis (Green Tea) Leaf Extract, Glycerin, Caprylic / Capric Triglycerides (Fractioned Coconut Oil), Simmondsia Chinensis (Jojoba) Seed Oil*, D-panthenol (Provitamin B5, plant-based ), Coco Glucoside, Squalane, Sodium Surfactin, Tocopherol (Vit E), Helianthus Annuus (Sunflower) Seed Oil*, Potassium Sorbate, Sodium Benzoate, Benzyl Alcohol, Citric Acid, Citrus Paradisi (Grapefruit) Peel Oil, Limonene, Citral, Linalool .\r\n*Bio",
                DescriptionBG = "Aqua, Vitis Vinifera (Grape) Seed Oil, Camellia Sinensis (Green Tea) Leaf Extract,  Glycerin, Caprylic / Capric Triglycerides (Fractioned Coconut Oil), Simmondsia Chinensis (Jojoba) Seed Oil*, D-panthenol (Provitamin B5, plant-based), Coco Glucoside, Squalane, Sodium Surfactin, Tocopherol (Vit E), Helianthus Annuus (Sunflower) Seed Oil*, Potassium Sorbate, Sodium Benzoate, Benzyl Alcohol, Citric Acid, Citrus Paradisi (Grapefruit) Peel Oil, Limonene, Citral, Linalool.\r\n*Био",
                DescriptionRO = "Aqua, ulei de semințe de Vitis Vinifera (struguri), extract de frunze de Camellia Sinensis (ceai verde), glicerină, trigliceride caprilice/caprice (ulei de cocos fracționat), ulei de semințe de Simmondsia Chinensis (jojoba)*, D-pantenol (provitamina B5, pe bază de plante) ), glucozid de coco, squalan, surfactin de sodiu, tocoferol (Vit E), ulei de semințe de Helianthus Annuus (floarea-soarelui)*, sorbat de potasiu, benzoat de sodiu, alcool benzilic, acid citric, ulei de coajă de Citrus Paradisi (grapefruit), limonen, citral, .\r\n*Bio"
            },
            new ()
            {
                Id = 21,
                DescriptionEN = "Gentle, all-natural and handmade deodorant. Suitable for daily use. The essential oils of sweet orange and eucalyptus impart a light citrus aroma.\r\n \r\nWe chose these essential oils not only for their pleasant aroma. They also have a better antibacterial effect than most essential oils. They even prevent the development of different types of fungi. This means it can naturally reduce the bad smell of sweat caused by underarm bacteria.\r\n \r\n100% natural\r\n45.7% from Bulgaria\r\n44.5% organic",
                DescriptionBG = "Нежен, изцяло натурален и ръчно изработен дезодорант. Подходящ за ежедневна употреба. Етеричните масла от сладък портокал и евкалипт придват лек цитрусов аромат.\r\n \r\nИзбрахме точно тези етерични масла не само заради приятния аромат. Те притежават и по-добър антибактериален фект спрямо повечето етерични масла. Дори пречат на развитието и на различни видове гъбички. Това ознчава, че натурално може да намали лошата миризма при потене, която е причинена от бактериите под мишниците.\r\n \r\n100% натурален\r\n45.7 % от България\r\n44.5% био",
                DescriptionRO = "Deodorant blând, natural și realizat manual. Potrivit pentru uz zilnic. Uleiurile esențiale de portocală dulce și eucalipt conferă o aromă ușoară de citrice.\r\n \r\nAm ales aceste uleiuri esențiale nu numai pentru aroma lor plăcută. De asemenea, au un efect antibacterian mai bun decât majoritatea uleiurilor esențiale. Ele previn chiar și dezvoltarea diferitelor tipuri de ciuperci. Aceasta înseamnă că poate reduce în mod natural mirosul urât al transpirației cauzat de bacteriile de la subrat.\r\n \r\n100% natural\r\n45,7% din Bulgaria\r\n44,5% organic"
            },
            new ()
            {
                Id = 22,
                DescriptionEN = "The essential oils of sweet orange and eucalyptus give a fresh, slightly minty citrus aroma and have an antibacterial effect.\r\n \r\nDry ingredients such as organic tapioca keep the underarms dry during the day.\r\n \r\nVitamin E has an antioxidant effect. \r\n \r\nAnd the whole combination of ingredients keeps unpleasant odors away.",
                DescriptionBG = "Етеричните масла от сладък портокал и евкалипт придават свеж, леко ментов цитрусов аромат и имат антибактериален ефект.\r\n \r\nСухите съставки като био тапиока поддържат подмишниците сухи през деня.\r\n \r\nВитамин Е има антиоксидантен ефект.\r\n \r\nА цялата комбинация от съставки държи неприятните миризми далеч.",
                DescriptionRO = "Uleiurile esențiale de portocală dulce și eucalipt conferă o aromă de citrice proaspătă, ușor mentată și au efect antibacterian.\r\n \r\nIngredientele uscate precum tapioca organică mențin axilele uscate în timpul zilei.\r\n \r\nVitamina E are efect antioxidant \r\n \r\nIar intreaga combinatie de ingrediente tine la distanta mirosurile neplacute."
            },
            new ()
            {
                Id = 23,
                DescriptionEN = "Take a very small amount (smaller than a pea) on the fingertips, warm it slightly between the fingers and spread it well under the armpits.\r\n \r\nFor external use only. Keep out of reach of children. Do not use if allergic to any of the ingredients. Store tightly closed in a dry place protected from direct sunlight.",
                DescriptionBG = "Вземете на върха на пръстите много малко количесто (по-малко дори от грахово зрънце), леко го затоплете между пръстите и разнесете добре подмишниците.\r\n \r\nСамо за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте добре затворено на сухо място, защитено от пряка слънчева светлина.",
                DescriptionRO = "Luați o cantitate foarte mică (mai mică decât un bob de mazăre) pe vârful degetelor, încălziți-o ușor între degete și întindeți-o bine sub axile.\r\n \r\nNumai pentru uz extern. A nu se lăsa la îndemâna copiilor. A nu se utiliza dacă este alergic la oricare dintre ingrediente. A se pastra bine inchis intr-un loc uscat ferit de lumina directa a soarelui."
            },
            new ()
            {
                Id = 24,
                DescriptionEN = "Once a shipping address or Econt or Speedy courier office is specified in the address fields when ordering, products are carefully packed in a recycled cardboard box and paper padding for a seal and sent by inspected delivery.",
                DescriptionBG = "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед.",
                DescriptionRO = "Odată ce o adresă de expediere sau un birou de curierat Econt sau Speedy este specificată în câmpurile de adresă în momentul comenzii, produsele sunt ambalate cu grijă într-o cutie de carton reciclat și căptușeală de hârtie pentru sigilare și trimise prin livrare inspectată."
            },
            new ()
            {
                Id = 25,
                DescriptionEN = "Vitis Vinifera (Grape) Seed Oil, Tapioca Starch*, Theobroma Cacao (Cocoa) Seed Butter*, Copernicia Cerifera Cera (Carnauba Wax)*, Sodium Bicarbonate, Glyceryl Stearate, Citrus Sinensis (Orange) Peel Oil*, Eucalyptus Globulus Leaf Oil* , Limonene**, Linalool**, Citral**, Tocopherol (Vit E), Helianthus Annuus (Sunflower) Seed Oil*\r\n*Bio\r\n**Essential Oil Components",
                DescriptionBG = "Vitis Vinifera (Grape) Seed Oil, Tapioca Starch*, Theobroma Cacao (Cocoa) Seed Butter*, Copernicia Cerifera Cera (Carnauba Wax)*, Sodium Bicarbonate, Glyceryl Stearate, Citrus Sinensis (Orange) Peel Oil*, Eucalyptus Globulus Leaf Oil*, Limonene**, Linalool**, Citral**, Tocopherol (Vit E), Helianthus Annuus (Sunflower) Seed Oil*\r\n*Bio\r\n**Компоненти на етерини масла",
                DescriptionRO = "Ulei de semințe de Vitis Vinifera (struguri), amidon de tapioca*, unt de semințe de cacao (cacao) de Theobroma*, Copernicia Cerifera Cera (ceară de carnauba)*, bicarbonat de sodiu, stearat de gliceril, ulei de coajă de Citrus Sinensis (portocale)*, globul de eucalipt* , Limonene**, Linalool**, Citral**, Tocoferol (Vit E), Ulei de semințe de Helianthus Annuus (floarea-soarelui)*\r\n*Bio\r\n**Componente ale uleiului esențial"
            },
            new ()
            {
                Id = 26,
                DescriptionEN = "Created to pamper yourself - with organic oils from: rosehip, strawberry seeds, argan and jojoba. Nourishes and protects the skin. Preserves hydration by protecting the skin from water loss and leaving it soft and smooth.\r\n \r\nEnriched with vitamin E for a good antioxidant effect that protects cells from the harmful effects of the environment, free radicals and oxidative processes. In this way, it keeps the skin young and elastic.\r\n \r\nRosehip oil is a natural source of vitamin A. Argan oil and strawberry seed oil nourish the skin, and jojoba oil contains natural ceramides, strengthen the skin barrier and strengthen bonds between cells.\r\n\r\nNon-comedogenic.\r\nBest for dry skin.\r\nOr as protection after a more exhausting routine, e.g. after a chemical peel.\r\nNourishes, strengthens and protects the skin barrier.\r\n \r\nUse a few drops on dry or damp skin (for example after a shower) or after a moisturizing lotion to 'lock in' hydration and protect the skin. \r\n \r\n100% natural\r\n80% from Bulgaria\r\n31% organic",
                DescriptionBG = "Създаден, за да се поглезите - с био масла от: шипка, ягодови семки, арган и жожба. Подхранва и защитава кожата. Запазва хидратацията като предпазва кожата от загуба на вода и я оставя мека и гладка.\r\n \r\nОбогатен с витамин Е за добър антиоксидантен ефект, който предпазва клетките от вредното въздействие отоколната среда, свободните радикали и оксидативни процеси. По този начин поддържа кожата млада и елстична.\r\n \r\nМаслото от шипка е натурален източник на витамин А. Аргановото масло и маслото от ягодови семки подхранват кожата, а маслото от жожоба съдържа натурални серамиди, подсилват кожната бариера и заздравяват връзките между клетките.\r\n\r\nНекомедогенен.\r\nНай-подходящ за суха кожа.\r\nИли като защита след по-изтощаваща рутина, напр. след химичен пилинг.\r\nПодхранва, заздравява и защитава кожната бариера.\r\n \r\nИзползвате няколко капки върху суха или влажна кожа (на пример след душ) или след хидратиращ лосион, за да 'заклчючите' хидратацията и да защитите кожата. \r\n \r\n100% натурален\r\n80% от България\r\n31% био",
                DescriptionRO = "Creat pentru a te rasfata - cu uleiuri organice din: macese, seminte de capsuni, argan si jojoba. Hraneste si protejeaza pielea. Păstrează hidratarea protejând pielea de pierderea apei și lăsând-o moale și netedă.\r\n \r\nÎmbogățit cu vitamina E pentru un bun efect antioxidant care protejează celulele de efectele nocive ale mediului, radicalilor liberi și proceselor oxidative. În acest fel, menține pielea tânără și elastică.\r\n \r\nUleiul de măceș este o sursă naturală de vitamina A. Uleiul de argan și uleiul de semințe de căpșuni hrănesc pielea, iar uleiul de jojoba conține ceramide naturale, întăresc bariera pielii și întărește legăturile dintre celule.\r\n\r\nNon-comedogenic.\r\nCel mai bun pentru pielea uscată.\r\nSau ca protecție după o rutină mai obositoare, de ex. după un peeling chimic.\r\nHrănește, întărește și protejează bariera cutanată.\r\n \r\nFolosește câteva picături pe pielea uscată sau umedă (de exemplu după un duș) sau după o loțiune hidratantă pentru a „bloca” hidratează și protejează pielea. \r\n \r\n100% natural\r\n80% din Bulgaria\r\n31% organic"
            },
            new ()
            {
                Id = 27,
                DescriptionEN = "Rosehip oil - helps revitalize the skin \r\nStrawberry seed oil - deeply hydrates and has an anti-inflammatory effect\r\nJojoba oil* - naturally contains over 95% ceramides, nourishes the skin and strengthens the skin barrier\r\nArgan oil* - nourishes, protects and improves the hydration and elasticity of the skin\r\nTangerine and ylang-ylang oils* - give a light, fresh and relaxing aroma to make the most of the skin care moment\r\nVitamin E* - antioxidant - soothes irritated skin and slows aging by fighting free radicals, UV damage and oxidation processes\r\n*Bio",
                DescriptionBG = "Масло от шипка - помога ревитализирането на кожата \r\nМасло от ягодови семки - хидратира в дълбочина и има протививъзвпалителен ефект\r\nМасло от жожоба* - натурално съдържа над 95% серамиди, подхранва кожата и заздравява кожната бариера\r\nАрганово масло* - подхранва, защитава и подобрява хидратацията и еластичносттна на кожата\r\nМсла от мандарина и иланг-иланг* - придават лек, свеж и релаксиращ аромат, за да се насладите максимално на момента в грижа за кожата\r\nВитамин Е* - антиоксидант - успокоява раздразнената кожа и забавя страеенето като бори се със свободните радикали, UV уверждането и процесите на оксидация\r\n*Био",
                DescriptionRO = "Ulei de măceș - ajută la revitalizarea pielii \r\nUlei din semințe de căpșuni - hidratează profund și are efect antiinflamator\r\nUlei de jojoba* - conține în mod natural peste 95% ceramide, hrănește pielea și întărește bariera pielii\r\nUlei de argan * - hrănește, protejează și îmbunătățește hidratarea și elasticitatea pielii\r\nUleiuri de mandarine și ylang-ylang* - oferă o aromă ușoară, proaspătă și relaxantă pentru a profita la maximum de momentul de îngrijire a pielii\r\nVitamina E* - antioxidant - calmează pielea iritată și încetinește îmbătrânirea prin combaterea radicalilor liberi, a daunelor UV și a proceselor de oxidare\r\n*Bio"
            },
            new ()
            {
                Id = 28,
                DescriptionEN = "For example, after a light moisturizing lotion to lock in hydration and beneficial ingredients.\r\nDirectly on damp skin for better absorption and protection.\r\nOr on dry skin to prevent transepidermal water loss from the skin.\r\n \r\nSuitable for skin protection at the end of the routine. Blends well after exfoliating and/or hydrating products.\r\n \r\nFor external use only. Keep out of reach of children. Do not use if allergic to any of the ingredients. Use with clean hands and skin. Store tightly closed, in a dry place, protected from direct sunlight.",
                DescriptionBG = "Например след лек хидратиращ лосион, за да заключи хидратацията и полезните съставки.\r\nДиректно върху влажна кожа за по-добро абсорбиране и защита.\r\nИли върху суха кожа, за да предотврати трансепидеррмалната загуба на вода от кожата.\r\n \r\nПодходящ за защита на кожата в края на рутината. Комбинира се добре след ексфолиращи и/или хидратиращи продукти.\r\n \r\nСамо за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Използвайте с чисти ръце и кожа. Съхранявайте добре затворено, на сухо място, защитено от пряка слънчева светлина.",
                DescriptionRO = "De exemplu, după o loțiune ușoară hidratantă pentru a bloca hidratarea și ingredientele benefice.\r\nDirect pe pielea umedă pentru o mai bună absorbție și protecție.\r\nSau pe pielea uscată pentru a preveni pierderea transepidermică de apă din piele.\r\n \r\nPotrivit pentru protecția pielii la sfârșitul rutinei. Se amestecă bine după produsele de exfoliere și/sau hidratare.\r\n \r\nNumai pentru uz extern. A nu se lăsa la îndemâna copiilor. A nu se utiliza dacă este alergic la oricare dintre ingrediente. Utilizați cu mâinile și pielea curate. A se pastra bine inchis, intr-un loc uscat, ferit de lumina directa a soarelui."
            },
            new ()
            {
                Id = 29,
                DescriptionEN = "Once a shipping address or Econt or Speedy courier office is specified in the address fields when ordering, products are carefully packed in a recycled cardboard box and paper padding for a seal and sent by inspected delivery.",
                DescriptionBG = "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед.",
                DescriptionRO = "Odată ce o adresă de expediere sau un birou de curierat Econt sau Speedy este specificată în câmpurile de adresă în momentul comenzii, produsele sunt ambalate cu grijă într-o cutie de carton reciclat și căptușeală de hârtie pentru sigilare și trimise prin livrare inspectată."
            },
            new ()
            {
                Id = 30,
                DescriptionEN = "Vitis Vinifera Seed Oil, Rosa Canina Seed Oil, Fragaria Ananassa Seed Oil, Argania Spinosa Kernel Oil, Simmondsia Chinensis Seed Oil (Jojoba Oil)*, Tocopherol (Vitamin E), Helianthus Annuus Seed Oil (Sunflower Oil <0.2%) *, Citrus Reticulata Oil (Mandarin Essential Oil), Limonene**, Linalool**, Cananga Odorata flower Oil (Ylang Ylanf essential oil) *.\r\n*Bio, 31%\r\n**Essential oil components",
                DescriptionBG = "Vitis Vinifera Seed Oil (масло от гроздови смеки), Rosa Canina Seed Oil (българско студенпресовно био масло от семената на шипка)*, Fragaria Ananassa Seed Oil (студенопресовано масло от семки на ягода), Argania Spinosa Kernel Oil (арганово масло)*, Simmondsia Chinensis Seed Oil (масло от жожоба)*, Tocopherol (Витамин E), Helianthus Annuus Seed Oil (Слънчогледово масло <0,2%) *,  Citrus Reticulata Oil (Етерично масло от мандарина) , Limonene**, Linalool**, Cananga Odorata flower Oil (Етерично масло от Иланг Иланф) *.\r\n*Био, 31%\r\n**Компоненети на етерични масла",
                DescriptionRO = "Ulei de semințe de Vitis Vinifera, ulei de semințe de Rosa Canina, ulei de semințe de Fragaria Ananassa, ulei de semințe de Argania Spinosa, ulei de semințe de Simmondsia Chinensis (ulei de jojoba)*, tocoferol (vitamina E), ulei de semințe de Helianthus annuus (ulei de floarea soarelui <0,2%) *, citrice Ulei de reticulata (ulei esential de mandarina), limonene**, linalool**, ulei de flori de cananga odorata (ulei esential de Ylang Ylanf) *.\r\n*Bio, 31%\r\n**Componente ale uleiului esential"
            },
            new ()
            {
                Id = 31,
                DescriptionEN = "",
                DescriptionBG = "",
                DescriptionRO = ""
            },
            new ()
            {
                Id = 32,
                DescriptionEN = "",
                DescriptionBG = "",
                DescriptionRO = ""
            },
            new ()
            {
                Id = 33,
                DescriptionEN = "",
                DescriptionBG = "",
                DescriptionRO = ""
            },
            new ()
            {
                Id = 34,
                DescriptionEN = "",
                DescriptionBG = "",
                DescriptionRO = ""
            },
            new ()
            {
                Id = 35,
                DescriptionEN = "",
                DescriptionBG = "",
                DescriptionRO = ""
            },
        ];

        public void Configure(EntityTypeBuilder<SectionDescription> builder)
        {
            builder.HasData(descriptions);
        }
    }
}
<div align="center">

<img src="https://capsule-render.vercel.app/api?type=waving&color=0:0D1117,50:2563EB,100:00FF88&height=180&section=header&text=Realtime%20Clock%20Overlay&fontSize=38&fontColor=ffffff&fontAlignY=40" width="100%" alt="Realtime Clock Overlay Banner" />

[![Game](https://img.shields.io/badge/Minecraft_Dungeons_II-UE_5.6-00FF88?style=for-the-badge)](https://github.com/X1miyaStudio/Realtime-Clock-MD2)
[![Release](https://img.shields.io/badge/GitHub_Release-v1.0.0-181717?style=for-the-badge&logo=github&logoColor=white)](https://github.com/X1miyaStudio/Realtime-Clock-MD2/releases/tag/v1.0.0)
![CurseForge](https://img.shields.io/badge/CurseForge-%D0%9D%D0%B0_%D0%BC%D0%BE%D0%B4%D0%B5%D1%80%D0%B0%D1%86%D0%B8%D0%B8-F16436?style=for-the-badge&logo=curseforge&logoColor=white)
![Loader](https://img.shields.io/badge/Blueprint_Loader-2.0%2B-blueviolet?style=for-the-badge)
[![SDK](https://img.shields.io/badge/Built_with-NeoRune-00BFFF?style=for-the-badge)](https://github.com/X1miyaStudio/Realtime-Clock-MD2)
[![Studio](https://img.shields.io/badge/Studio-X1miyaStudio-064E3B?style=for-the-badge)](https://t.me/X1miyaStudio)

<p align="center">
  <b>Настраиваемый оверлей реального времени для Minecraft Dungeons II.</b><br/>
  Оформлен в стиле родного интерфейса игры, поддерживает 12ч/24ч форматы, секунды, выбор позиции и меню настроек Blueprint Loader 2.0+.
</p>

<p align="center">
  <a href="README.md">
    <img src="https://img.shields.io/badge/Language-English-0D1117?style=flat-square&logo=googletranslate&logoColor=white" alt="English Version" />
  </a>
  <img src="https://img.shields.io/badge/%D0%AF%D0%B7%D1%8B%D0%BA-%D0%A0%D1%83%D1%81%D1%81%D0%BA%D0%B8%D0%B9-00FF88?style=flat-square" alt="Русский" />
</p>

</div>

---

## ✨ Возможности

* **Локальное реальное время** — отображает системные часы прямо в игре и продолжает обновляться даже на паузе.
* **Не мешает управлению** — использует `HitTestInvisible` и никогда не перехватывает клики мыши в меню и бою.
* **Стилизация под игру** — трёхслойная сланцево-каменная рамка с тенью текста в духе интерфейса Minecraft Dungeons II.
* **Гибкие настройки прямо в игре (`Настройки → Моды`):**
  * Включение/выключение и горячая клавиша скрытия (`F9` по умолчанию).
  * Отображение в главном меню и поверх инвентаря/паузы.
  * Формат `24ч` / `12ч AM/PM` и отображение секунд.
  * 5 позиций на экране (`Top Right`, `Top Left`, `Bottom Right`, `Bottom Left`, `Top Center`) и отступы X/Y.
  * Размер шрифта, цвет текста (`#HEX`) и прозрачность фона.

---

## 📥 Требования и установка

1. Установите **Blueprint Loader 2.0+** в `Dungeons\Content\Paks\~mods\BlueprintLoader\`.
2. Скачайте `RealtimeClockOverlay-1.0.0.zip` из [GitHub Releases](https://github.com/X1miyaStudio/Realtime-Clock-MD2/releases).
3. Закройте **Minecraft Dungeons II** и распакуйте папку `RealtimeClock` в:
   * **Steam:** `<SteamLibrary>\steamapps\common\Minecraft Dungeons II\Dungeons\Content\Paks\~mods\RealtimeClock\`
   * **Xbox App / Game Pass:** `<Drive>:\XboxGames\Minecraft Dungeons II\Content\Dungeons\Content\Paks\~mods\RealtimeClock\`
4. Запустите игру и настройте часы во вкладке **Settings → Mods → Realtime Clock Overlay**.

---

## 🛠️ Сборка из исходников

Требуется **.NET 10 SDK** и `NeoRune`:

```powershell
dotnet build -c Release
neorune pack
```

---

<div align="center">
  <b>— X1miyaStudio🧪</b><br/>
  <a href="https://t.me/X1miyaStudio">Telegram</a> · <a href="https://discord.gg/pwk6X8ecNJ">Discord</a> · <a href="https://www.youtube.com/@X1miyaStudio">YouTube</a>
</div>

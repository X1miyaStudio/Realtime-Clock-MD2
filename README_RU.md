<div align="center">

<img src="https://capsule-render.vercel.app/api?type=waving&color=0:0D1117,50:2563EB,100:00FF88&height=180&section=header&text=Realtime%20Clock%20Overlay&fontSize=38&fontColor=ffffff&fontAlignY=40" width="100%" alt="Realtime Clock Overlay Banner" />

<p align="center">
  <b>Настраиваемый оверлей реального времени для Minecraft Dungeons II.</b><br/>
  Оформлен в стиле родного интерфейса игры, поддерживает 12ч/24ч форматы, секунды, выбор позиции и меню настроек Blueprint Loader 2.0+.
</p>

<p align="center">
  <a href="README.md">🇬🇧 English documentation</a>
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

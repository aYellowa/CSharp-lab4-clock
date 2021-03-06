# Разработка аналоговых часов

**Цель работы:** научиться создавать приложения Windows Forms с использованием элементов графики, изучить событие **Paint**.

## Часы

В данной работе нужно написать реализацию стрелочных часов.

![](clock.png)

## Выполнение работы

Объявление пакетов:

```
using System.Drawing;
using System.Drawing.Drawing2D;
```


Главный код программы сосредоточен в функции-обработчике события

```
 private void Form_Paint(object sender, PaintEventArgs e)
```

Алгоритм работы обработчика можно описать следующим образом:

- Получение доступа к текущему времени 
  ```DateTime dt = DateTime.Now;```
- Создание перьев и кистей для рисования
  ```
   Pen cir_pen = new Pen(Color.Black,2);
   Brush brush = new SolidBrush(Color.Indigo); 
  ```
- Получение графического контекста 
  ```
   Graphics g = e.Graphics;
  ```
- Объявление объекта для сохранения текущего состояния
  ```
   GraphicsState gs;
  ```
  
- Масштабирование рисунка и перенесение начала координат в центр
  ```
  g.TranslateTransform(w / 2, h / 2);
  g.ScaleTransform(w / 200, h / 200);
  ```
- Рисование циферблата
  ```
  g.DrawEllipse(cir_pen, -120, -120, 240, 240);
  ```
- Рисование стрелок

  Стрелки рисуются в виде прямых линий или соединенных несколько точек линиями (Polygon). Положение линий определяется текущим временем, которое нужно перевести в градусы поворота относительно начала координат на окружности (вертикальная линия).
  ```
  gs = g.Save();
  g.RotateTransform(6 * (dt.Minute + (float)dt.Second / 60));
  g.DrawLine(new Pen(new SolidBrush(Color.Brown), 4), 0, 0, 0, -80);
  g.Restore(gs);
  ```
  Сначала сохраняется текущее состояние, потов выполняется поворот на заданное количество градусов и рисуется линия. Потом восстанавливается текущее состояние графического контекста. 
  
  - Для активизации процедуры рисования надо создать элемент управления **Timer** и назначить обработчик события **Tick** (с частотой 1 раз в секунду)
  
  ```
   private void timer1_Tick(object sender, EventArgs e)
   {
       this.Invalidate();
   }
   ```
   вызов **Invalidate()** приводит к необходимости перерисовки формы, для чего вызывается обработчик **Paint**

## Результаты работы

Результаты работы в виде файлов проекта (кроме исполняемых, находящихся в папке `Debug` или `Release`) прислать в пул-запросе (в папке `App`) для своей ветки. Сделать скриншот главного окна приложения Windows Forms и поместить файл в папку `src`.

## Алгоритм выполнения работы

Для выполнения работы необходимо:

1. Выполнить *fork* репозитария в свой аккаунт.
1. Выполнить клонирование репозитария из своего аккаунта к себе на локальную машину (`git clone`).
1. Создать ветку **git** с индивидуальным номером (`git branch имя_ветки`).
1. Сделать ветку активной (`git checkout имя`).
1. Необходимо разместить исходные файлы с решениями задач, поместив **.h, .cpp, .cs** в подкаталоге **src** репозитория и скриншот главного окна приложения.
1. Добавить файлы в хранилище (`git add`).
1. Выполнить фиксацию изменений (`git commit -m "комментарий"`).
1. Отправить содержимое ветки в свой удаленный репозиторий (`git push origin имя_ветки`).
1. Создать пул-запрос в репозиторий группы и ждать результата 


|  ФИО              | Имя ветки |
|-------------------|-----------|
| Афанасьев А.     | b1 |
| Воронов Д.    | b2 |
| Баландин А.    | b3 |
| Бритова Ю.|  b4 |
| Голованов Д.         | b5  |
| Головин Д.        | b6 |
| Гордеев В.       | b7 |
| Дукова Е.     | b8 |
| Комаров Д.       | b9 |
| Кузминский И.     | b10 |
| Кузьмин А.          | b11 |
| Кулаков Р.  | b12  |
| Майоров Н.     | b13 |
| Матвеев С.        | b14 |
| Мизгирев А.            | b15 |
| Мишанина П. | b16 |
| Новикова В.     | b17 |
| Орлов А.      | b18 |
| Слащева Я. | b19 |
| Сорокин А. | b20 |

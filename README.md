# E-learning-WindowsForms
Побудувати WindowsForms проект для роботи з геометричними фігурами. 
Головне меню містить 
1) File меню (New – утворення чистого полотна для малювання, Open – відкрити діалог з вибором файлу збереженого полотна з фігурами, Save – зберегти полотно з фігурами у файл) . 
2) Shapes меню – в якому динамічно додаються пункти меню – список фігур намальованих на полотні. Після вибору однієї з фігур з допомогою мишки або клавіш руху можна переміщати фігуру по полотні. В контекстному меню теж відображати фігури і аналогічні дії.
Інформацію про фігури зберігати в об’єктному вигляді (ієрархія класів, типу Shape-Circle, реалізація необхідних інтерфейсів IMoveable, IPaintable), збереження у файли – сериалізація в XML форматі.
При клацанні на полотні певну кількість разів (кількість вершин  чи центр та радіус кола)  – утворюється фігура з вказаними координатами і надається діалог для вибору кольору.
Не забуваєм про розділення рівня дуступу до даних, бізнес логіки на представлення та про юніт тести.

Варіант: 4)коло

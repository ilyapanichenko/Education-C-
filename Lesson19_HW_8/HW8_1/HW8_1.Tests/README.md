### Проект SauceDemo

1. Создать новый проект SauceDemo
2. Расшарить на Github и пригласить ментора в коллабораторы
3. Создать новый класс, в нем для ресурса https://www.saucedemo.com/ составить
   список локаторов, можно искать на ВСЕХ страницах приложения
   (driver.findWebElement(<локатор>)) для КАЖДОГО из примеров локаторов
   ниже:
   ● id
   ● name
   ● classname
   ● tagname
   ● linktext
   ● partiallinktext
   ● xpath
   ○ Поиск по атрибуту, например By.xpath("//tag[@attribute='value']");
   ○ Поиск по тексту, например By.xpath("//tag[text()='text']");
   ○ Поиск по частичному совпадению атрибута, например
   By.xpath("//tag[contains(@attribute,'text')]");
   ○ Поиск по частичному совпадению текста, например
   By.xpath("//tag[contains(text(),'text')]");
   ○ ancestor, например //*[text()='Enterprise Testing']//ancestor::div
   ○ descendant
   ○ following
   ○ parent
   ○ preceding
   ○ Подсказка: XPath Axes
   ○ *поиск элемента с условием AND, например //input[@class='_2zrpKA
   _1dBPDZ' and @type='text']

● css
○ .class
○ .class1.class2
○ .class1 .class2
○ #id
○ tagname
○ tagname.class
○ [attribute=value]
○ [attribute~=value]
○ [attribute|=value]
○ [attribute^=value]
○ [attribute$=value]
○ [attribute*=value]
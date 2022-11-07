# PaymentsReconciliation

## Summary
Console App that perfrom the download of a file, PaymentsReconciliation.json, calculated from the manipulation of three files:
1. Payments.json
2. Prices.xml
3. Purchases.dat

## Task

### Files
Consider the following three datasets provided to you as files:
1. Purchases.dat
This is a list of fictitious purchase transactions. Each purchase transaction block begins with one customer (CUST) record, followed by one purchase date record (DATE) and then by one or more item records (ITEM).
- A CUST record is formed by the word “CUST” followed by a customer number (6 digits with leading
zeroes).
- A DATE record is formed by the word “DATE” followed by the date value: day (2 digits), month (2
digits), year (4 digits), hour (2 digits 0-23) and minute (2 digits).
- An ITEM record is formed by the word “ITEM” followed by an item number (6 digits with leading
zeroes).

'''
  CUST<customer number (with leading zeroes)>
  DATE<purchase date (“day month year hour minute” in numbers without spaces)>
  ITEM<item number (with leading zeroes)>
  ITEM<item number (with leading zeroes)>
  …
  CUST<customer number (with leading zeroes)>
…
'''

2. Prices.xml
The “Prices” dataset contains a price for each item of the store in XML format.

'''
  <ItemPricesRoot>
   <ItemPricesList>
   <ItemPrice>
   <Item>000001</Item>
   <Price>27.06</Price>
   </ItemPrice>
   <ItemPrice>
   <Item>000002</Item>
   <Price>12.7</Price> 
   </ItemPrice>
   …
   </ItemPricesList>
  </ItemPricesRoot>
'''

3. Payments.json
This is a list of monthly payments made by the store customers in favor of the store. Each monthly payment
should cover all purchases done by the customer in that month.

'''
  [
   {
   "Customer": "000001",
   "Year": 2018,
   "Month": 1,
   "Amount": 1074.97
   },
   {
   "Customer": "000001",
   "Year": 2018,
   "Month": 2,
   "Amount": 492.31
   },
  …
'''

### App Reconciliation
Write a Console application that reads the three files above and creates a json file called PaymentsNotMatched.json containing: customer, year, month, amount due, amount payed and the difference between due and payed for any customers/month having non zero difference between due and
payed (i.e. include only unmatched payments). Items with the biggest difference between due and payed (in absolute value) should be reported first.

Optionally consider if you can enable saving the PaymentsNotMatched report in a different format – like CSV or narrative text. 

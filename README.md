# StockListAPI (.NET 6 WebAPI)

Fetch Stock Symbols from NASDAQ website. 

This program parses a text file provided by NASDAQ (http://ftp.nasdaqtrader.com/) and returns a list of strings of all stocks available. Data is parsed each request so as the website is updated, data in the response should be up to date as well.

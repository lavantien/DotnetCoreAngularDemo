use master

if not exists (select name from sys.databases where name = N'FlowersWebShop') create database FlowersWebShop

use FlowersWebShop
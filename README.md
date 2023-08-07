# RabitMq

1. direct : In this type routekey must be equal in producer and consumer and this is 1-1
2. fanout : In this type every queue that binded to fanout exchange, will recived message and this is  1-many
3. topic : In this type set a routekey for producer with special pattern and everyqueue that binded to topic exchange in consumer and the routekey of consumer support producer routkey  , will recived message  this is 1-many

* means you must use one word
# means you can you no word or many word


sample: producer rout key is : aaa.bbb.ccc

valid consumer patter like  :  aaa.# , *.bbb.*

unvalid consumer patter like: aaa.*  ,  *.ccc




4. header :

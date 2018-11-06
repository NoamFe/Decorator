# Decorator
Decorator design pattern example

In this example we can see how we have ```OrderService``` that is implementing ```IOrderService```.
Now we want to have a cache service. one option would be to modify that ```OrderService``` but that is violating the open close principal.

The solution is to have a decorator to OrderService. We will call it ```OrderCacheService```.
```OrderCacheService``` will decorate ```OrderService``` which means it will hold that class and add some functionality like calling a cache service ```ICacheService```

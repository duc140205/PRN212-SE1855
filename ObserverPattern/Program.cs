using ObserverPattern;

var subject = new Subject();

var observerA = new ConcreteObserverA();
subject.Attach(observerA);

var observerB = new ConcreteObserverB();
subject.Attach(observerB);

// Giả lập một số thay đổi
subject.SomeBusinessLogic();
subject.SomeBusinessLogic();

// Bỏ observerA và kiểm tra tiếp
subject.Detach(observerA);
subject.SomeBusinessLogic();
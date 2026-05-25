clc;
clear;
close all;

%1. Підготовка даних до навчання
X=[3 4 10 7 5 1 6 6;
   100 300 500 100 200 250 210 50];
T=[0 0 1 1 0 0 1 1;
   0 1 1 0 0 1 1 0];
maxC=max(X(1, :));
maxP=max(X(2, :));
X=[X(1, :)/maxC;X(2, :)/maxP];
figure (1)
plotpv(X,T, [0,1.1,0,1.1]);
grid on;

%2. Формування архітектури мережі
my_net=newp(X,T,'hardlim','learnpn');


% 3. Ініціалізація мережі
 my_net = init(my_net);
% my_net.IW{1,1}=[10 20];
% my_net.b{1}=5;
my_net.IW{1,1}
my_net.b{1}

% 4. Навчання мережі
my_net_train = train(my_net, X, T);
my_net_train.IW{1,1}
my_net_train.b{1}



hold on
plotpc(my_net_train.IW{1,1}, my_net_train.b{1});

% 5. Тестування навчальної мережі
Y = sim(my_net_train, X)
Y1 = sim(my_net_train, [2/maxC;100/maxP])
Y2 = sim(my_net_train, [8/maxC;400/maxP])
Y3 = sim(my_net_train, [1/maxC;350/maxP])
Y4 = sim(my_net_train, [6/maxC;150/maxP])

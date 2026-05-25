clc;
clear;
close all;

%1. Підготовка даних до навчання
X=[-1.5 1.5 -1.5 1.5 -1.5 1.5 -1.5 1.5;
   -1.5 -1.5 1.5 1.5 -1.5 -1.5 1.5 1.5;
   -1.5 -1.5 -1.5 -1.5 1.5 1.5 1.5 1.5];
T=[1 0 0 0 1 1 1 0];

figure (1)
plotpv(X,T, [-6,4,-6,4,-6,4]);
grid on;

%2. Формування архітектури мережі
my_net=newp(X,T);

% 3. Ініціалізація мережі
%  my_net = init(my_net);
% my_net.IW{1,1}=[10 20 20];
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
Y1 = sim(my_net_train, [0;0;0])
Y2 = sim(my_net_train, [1;1;1])


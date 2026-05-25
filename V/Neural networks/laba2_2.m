clc;
clear;
close all;

%1. Підготовка даних до навчання
X=[5.25 5 5.75 5 4.5 6 4.5 5.5 7 4   3.5 4.5 5 6.5 7.5   1 1.5 2       10 9.5    5 5.5   1 2 2 3.5 3 4         6.5 7 8 8.5 8 9.5;
   7.75 7 6.5 6 5.5 5 4.5 4 4 4       2 2.5 1 2.5 1       2.5 1.5 2.5    1.5 2.5  9.5 10    4 5 6.5 6.5 7.5 8.5   8.5 7 8 6.5 5 4];
T=[0 0 0 0 0 0 0 0 0 0    0 0 0 0 0   0 0 0   1 1   1 1   0 0 0 0 0 0   1 1 1 1 1 1 ;
   0 0 0 0 0 0 0 0 0 0    1 1 1 1 1   1 1 1   1 1   0 0   0 0 0 0 0 0   0 0 0 0 0 0 ;
   0 0 0 0 0 0 0 0 0 0    0 0 0 0 0   1 1 1   0 0   1 1   1 1 1 1 1 1   0 0 0 0 0 0 ];
maxC=max(X(1, :));
maxP=max(X(2, :));

% % tempX1=X(1, :)/maxC;
% % tempX2=X(2, :)/maxP;
X=[X(1, :)/maxC;X(2, :)/maxP];

figure (1)
plotpv(X,T, [0,1.1,0,1.1]);
grid on;

%2. Формування архітектури мережі
my_net=newp(X,T,'hardlim','learnpn');

% % Настройка функции обучения learnpn
% my_net.inputWeights{1,1}.learnFcn = 'learnpn';
% my_net.biases{1}.learnFcn = 'learnpn';

% 3. Ініціалізація мережі
% my_net.trainParam.epochs = 10000;
% my_net.trainParam.goal = 1e-2

 my_net = init(my_net);
% my_net.IW{1,1}=[10 20];
% my_net.b{1}=5;
my_net.IW{1,1,1}
my_net.b{1}

% 4. Навчання мережі
my_net_train = train(my_net, X, T);
my_net_train.IW{1,1,1}
my_net_train.b{1}

hold on
plotpc(my_net_train.IW{1,1}, my_net_train.b{1});

% 5. Тестування навчальної мережі
Y = sim(my_net_train, X)
Y1 = sim(my_net_train, [5.5/maxC;5/maxP])
Y2 = sim(my_net_train, [1/maxC;1/maxP])
Y3 = sim(my_net_train, [1/maxC;1/maxP])


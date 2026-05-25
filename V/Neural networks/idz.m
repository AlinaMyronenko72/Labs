clc;
clear;
close all;

%1. Підготовка даних до навчання
X = [0.1 0.1 0.15 0.3 0.35 0.45 0.6 0.7 0.75 0.9 1 0.9;  
     0.6 0.4 0.5 0.4 0.55 0.45 0.4 0.6 0.4 0.4 0.5 0.6];
Tc = [1 1 1 2 2 2 1 1 1 2 2 2];
I1 = find (Tc == 1); 
I2 = find (Tc == 2);
figure(1); 
axis([0, 1.1, 0, 1]); 
hold on; 
plot (X(1, I1), X(2, I1), '+g');
plot (X(1, I2), X(2, I2), 'ob');

%2. Формування архітектури мережі
my_net = lvqnet (4,0.1,'learnlv1')

%3. Підготовка до навчання
T = ind2vec (Tc);
full (T)
net.trainParam.epochs = 10000;  % Кількість епох
my_net = init(my_net);


% my_net.IW{1,1}
% my_net.b{1}

% 4. Навчання мережі
my_net_train = train ( my_net, X, T )
% hidden_layer_weights = my_net.IW{1,1};
Y = sim (my_net_train, X);
Yc = vec2ind (Y)
% my_net_train.IW{1,1}
% my_net_train.b{1}
% disp('Ваги нейронів прихованого шару:')
% disp(my_net_train.IW{1,1})
% disp('Зсуви нейронів прихованого шару:')
% disp(my_net_train.b{1})
w1 = my_net_train.IW{1,1};
hold on
plot(w1(:,1),w1(:,2),'*k')

% plotpc(my_net_train.IW{1}, my_net_train.b{1});
%5. Тестування мережі
Xt = [0.15 0.4 0.7 1 ; 
      0.4 0.1 0.5 0.3];


Yt = sim(my_net_train, Xt);
Yct = vec2ind(Yt)
figure(2);
axis([0, 1.1, 0, 1]);
hold on;
plot(X(1, I1), X(2, I1), '+g');
plot(X(1, I2), X(2, I2), 'ob');
plot(Xt(1, Yct == 1), Xt(2, Yct == 1), '+r');
plot(Xt(1, Yct == 2), Xt(2, Yct == 2), 'or');
plot(w1(:,1),w1(:,2),'*k')
% % Додаємо центри кластерів (ваги нейронів прихованого шару)
% disp('Ваги нейронів прихованого шару:')
% disp(my_net_train.IW)
% plot(my_net_train.IW(:, 1), my_net_train.IW(:, 2), 'xk', 'MarkerSize', 10, 'LineWidth', 2);
% % legend('Class 1', 'Class 2', 'Test Class 1', 'Test Class 2', 'Cluster Centers');


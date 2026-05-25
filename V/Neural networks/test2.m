clc;
clear;
close all;

% 1. Підготовка даних до навчання
X = [0.1 0.1 0.15 0.3 0.35 0.45 0.6 0.7 0.75 0.9 1 0.9;  
     0.6 0.4 0.5 0.4 0.55 0.45 0.4 0.6 0.4 0.4 0.5 0.6];
Tc = [1 1 1 2 2 2 1 1 1 2 2 2];
I1 = find(Tc == 1); 
I2 = find(Tc == 2);

figure(1); 
axis([0, 1.1, 0, 1]); 
hold on; 
plot(X(1, I1), X(2, I1), '+g');
plot(X(1, I2), X(2, I2), 'ob');

% 2. Формування архітектури мережі
my_net = lvqnet(4, 0.01, 'learnlv1');

% 3. Підготовка до навчання
T = ind2vec(Tc);
net.trainParam.epochs = 10000;  % Кількість епох
my_net = init(my_net);

% 4. Навчання мережі
my_net_train = train(my_net, X, T);

% Витягаємо ваги нейронів прихованого шару
hidden_layer_weights = my_net_train.IW{1,1};

% Відображення навчальних даних та центрів кластерів
hold on;
plot(hidden_layer_weights(:, 1), hidden_layer_weights(:, 2), 'xk', 'MarkerSize', 10, 'LineWidth', 2);
legend('Class 1', 'Class 2', 'Cluster Centers');

% 5. Тестування мережі
Xt = [0.15 0.4 0.7 1; 
      0.4 0.1 0.5 0.3];

Yt = sim(my_net_train, Xt);
Yct = vec2ind(Yt);

figure(2);
axis([0, 1.1, 0, 1]);
hold on;
plot(X(1, I1), X(2, I1), '+g');
plot(X(1, I2), X(2, I2), 'ob');
plot(Xt(1, Yct == 1), Xt(2, Yct == 1), '+r');
plot(Xt(1, Yct == 2), Xt(2, Yct == 2), 'or');

% Додаємо центри кластерів (ваги нейронів прихованого шару)
disp('Ваги нейронів прихованого шару:')
disp(hidden_layer_weights)
plot(hidden_layer_weights(:, 1), hidden_layer_weights(:, 2), 'xk', 'MarkerSize', 10, 'LineWidth', 2);
legend('Class 1', 'Class 2', 'Test Class 1', 'Test Class 2', 'Cluster Centers');

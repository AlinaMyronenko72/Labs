% Векторні дані для двох класів
class1 = [randn(50, 2) + 1; randn(50, 2) - 1];
class2 = [randn(50, 2) + 3; randn(50, 2) - 3];

% Позначки класів
labels1 = ones(100, 1);
labels2 = -ones(100, 1);

% Об'єднання даних і позначок
data = [class1; class2];
labels = [labels1; labels2];

% Візуалізація даних
figure;
scatter(class1(:,1), class1(:,2), 'r');
hold on;
scatter(class2(:,1), class2(:,2), 'b');
title('Дані двох класів');
legend('Клас 1', 'Клас 2');
hold off;
% Визначення початкових кодових векторів (прототипів)
initial_prototypes = [mean(class1); mean(class2)];

% Навчання LVQ1
net1 = lvqnet(2, 0.1, 'learnlv1');
net1.IW{1,1} = initial_prototypes;

% Підготовка даних для навчання
training_data = data';
training_labels = labels';

% Навчання мережі
net1 = train(net1, training_data, training_labels);
% Тестові дані
test_data = [randn(50, 2) + 2; randn(50, 2) - 2];
test_labels = [ones(25, 1); -ones(25, 1)];

% Класифікація тестових даних
test_results = net1(test_data');
predicted_labels = sign(test_results);

% Візуалізація результатів тестування
figure;
gscatter(test_data(:,1), test_data(:,2), predicted_labels, 'rb', 'xo');
title('Результати класифікації за допомогою LVQ1');
legend('Клас 1', 'Клас 2');
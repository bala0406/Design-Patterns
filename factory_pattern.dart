import 'dart:convert';
import 'dart:io';

abstract class EnemyShip {
  String _name;
  double _amtDamage;

  String getName() {
    return _name;
  }

  void setName(String newName) {
    _name = newName;
  }

  double getDamage() {
    return _amtDamage;
  }

  void setDamage(double newDamage) {
    _amtDamage = newDamage;
  }

  void followHeroShip() {
    print(getName() + ' is following the hero');
  }

  void displayEnemyShip() {
    print(getName() + ' is on the screen');
  }

  void enemyShipShoots() {
    print(getName() + 'attacks and does ' + getDamage().toString());
  }
}

class UFOEnemyShip extends EnemyShip {
  UFOEnemyShip() {
    setName('UFO Enemy Ship');
    setDamage(20);
  }
}

class RocketEnemyShip extends EnemyShip {
  RocketEnemyShip() {
    setName('Rocket Enemy Ship');
    setDamage(10);
  }
}

class BigUFOEnemyShip extends EnemyShip {
  BigUFOEnemyShip() {
    setName('Big UFO Enemy Ship');
    setDamage(40.0);
  }
}

class EnemyShipFactory {
  EnemyShip makeEnemyShip(String newShipType) {
    if (newShipType == 'U') {
      return UFOEnemyShip();
    } else if (newShipType == 'R') {
      return RocketEnemyShip();
    } else if (newShipType == 'B') {
      return BigUFOEnemyShip();
    }
    return null;
  }
}

class EnemyShipTesting {
  static void doStuffEnemy(EnemyShip aEnemyShip) {
    aEnemyShip.displayEnemyShip();
    aEnemyShip.followHeroShip();
    aEnemyShip.enemyShipShoots();
  }
}

void main() {
  var shipFactory = EnemyShipFactory();
  EnemyShip theEnemy;
  print('What type of ship(U/R/B)');
  var typeOfShip = stdin.readLineSync();
  theEnemy = shipFactory.makeEnemyShip(typeOfShip);

  if (theEnemy != null) {
    EnemyShipTesting.doStuffEnemy(theEnemy);
  } else {
    print('Enter correct value');
  }
}

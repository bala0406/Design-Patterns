class BoeingAltitudeMonitor{
    fun autoMonitor() : Unit{
        println("altitude set to auto monitor")
    }
    
    fun turnOff() : Unit{
        println("alititude auto monitor turned off")
    }
}

class BoeingEngineController{
    
    private var _engineSpeed : Int = 0
    
    var engineSpeed : Int
    	get() = _engineSpeed
    	set(value){
            println("engine speed set to ${value}")
            _engineSpeed = value
        }
    
    fun turnOff() : Unit{
        println("engine turned off")
    }
}

class BoeingFuelMonitor{
    
    var _remainingFuelInGallons : Int = 0
    
    fun	getRemainingFuelInGallons(engineSpeed : Int) : Int{
        return engineSpeed / 5
    }
    
    fun turnOff() : Unit{
        println("fuel monitor turned off")
    }
}

class BoeingNavigationSystem{
    
    fun setDirectionBasedOnSpeedAndFuel(engineSpeed : Int, remainingFuel : Int){
        println("engine speed is ${engineSpeed} and remaining fuel is ${remainingFuel}")
    }
    
    fun turnOff() : Unit{
        println("navigation system turned off")
    }
}

class AutoPilotFacade(val altitudeMonitor : BoeingAltitudeMonitor, val engineController : BoeingEngineController,
                        val fuelMonitor : BoeingFuelMonitor, val navigationSystem : BoeingNavigationSystem){
    
    fun autoPilotOn() : Unit{
        altitudeMonitor.autoMonitor();
        engineController.engineSpeed = 200;
        navigationSystem.setDirectionBasedOnSpeedAndFuel(engineController.engineSpeed, 
                                                            fuelMonitor.getRemainingFuelInGallons(engineController.engineSpeed))
    }
    
    fun autoPilotOff() : Unit{
        altitudeMonitor.turnOff();
        engineController.turnOff();
        fuelMonitor.turnOff();
        navigationSystem.turnOff();   
    }
}

fun main(args : Array<String>){
    val autoPilotFacade = AutoPilotFacade(BoeingAltitudeMonitor(), BoeingEngineController(), 
                                            BoeingFuelMonitor(), BoeingNavigationSystem())
    autoPilotFacade.autoPilotOn()
    autoPilotFacade.autoPilotOff()
}

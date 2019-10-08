//! \mainpage AWG Test Framework
//! 
//! \section intro_sec Introduction
//!  
//! Introduction section.
//!
//! \section groups Groups
//! 
//! The test framework steps are divided into different groups or categories. The following is a list 
//! with links to each page.
//!
//! \ref controls
//! @n
//! Use these steps to control operating modes.
//!
//! \ref calibrations
//! @n
//! Use these steps to calibrate the arbitrary waveform generator.
//!
//! \ref diagnosticss
//! @n
//! Use these steps to control self-test diagnostic routines.
//!
//!\ref gpibs 
//! @n
//! Use these steps to configure the GPIB usb adapter settings.
//!
//! \ref massmemorys
//! @n
//! Use these steps to read/write data from/to hard disk on the instrument.
//!
//! \ref outputs
//! @n 
//! Use these steps to set or return the characteristics of the output port of the arbitrary 
//! waveform generator.
//!
//!\ref sequences
//! @n
//! Use these steps to define and edit a sequence.
//!
//!\ref sources
//! @n
//! Use these steps to set and query the waveform or marker output parameter.
//!
//!\ref statuses
//! @n
//! Use these steps to set and query the registers/queues of the arbitrary waveform generator
//! event/status reporting system.
//!
//!\ref syncs
//! @n
//! Use these steps to prevent external communication from interfering with arbitrary waveform generator operation. 
//!
//!\ref systems
//! @n
//! Use these steps to control miscellaneous instrument functions. 
//!
//!\ref triggers
//! @n
//! Use these steps to synchronize the arbitrary waveform generator actions with events.
//!
//!\ref waveforms
//! @n
//! Use these steps to load, save and get information for waveforms for the arbitrary waveform generator.
//!  
//! \section types Types
//! There are two different types of steps, PI and UI. Classified via classes down to each individual step rather than by steps up to each class. 
//! @n @n
//! \ref pisteps
//! @n
//! The PI steps deal strictly with the programmable interfaces using TekVisa.
//! 
//! \ref uisteps
//! @n
//! The UI steps deal strictly with the User interface interface using White.
//!
//! \subsection highstepsection Steps
//! The step definition for PI normally has 3 forms: a "set", a "get" and a "should be".
//! There may not always be 3 forms for the PI command and may only have a "set" or a "get".
//! An example of a "set" only would be a PI command that forces a trigger.
//! An example of the "get" would be to get the state of the AWG.
//! In addition there are exceptions for some PI commands such as delete and save functions.
//! The main responsibility of the step is to ensure that all the parameters that are passed
//! to the next layer (group-helper) are valid.@n
//! \ref highui@n
//! \ref highpi
//! 
//! \subsection lowstepsection Group Helpers
//! The group helpers for the PI set and get the values for commands, and test the raw values as returned from the 
//! instrument. They DO NOT interpret values in any way! Notice the use of the word "value" in this helpers - this 
//! usually implies that the query returns a 0 or 1 or abbreviated text value (like SOFT) that should 
//! be interpreted as ON or OFF or SOFTWARE to make the step more user-friendly. @n
//! \ref grouphelperpi
//!
//! \subsection othersetupsection Other Setup
//! Classes used for setup and talking to the instruments in the test framework.@n
//! \ref othersetup
//!
//!\subsection dutsection DUT Steps
//! Classes and steps used for stepup with the AWG 70k and potentially 50k in the test framework.@n
//! \ref dutsteps
//!
//! \subsection extsourcesection External Source Steps
//! PI steps defined to be used for working with an external source, maninly a 5k or 7k to provide a signal.@n
//! \ref extsourcesteps
//!
//! \subsection scopesection Scope Steps
//! PI steps defined to be used for working with an Scope, will be using a DPO 7k or a CSA8000B.@n
//! \ref scopesteps
//!

//! \defgroup pisteps PI Steps 
//! \brief This group holds all of the PI step classes
//! \{ 
 
//! \defgroup  highpi PI Steps 
//! \brief This group holds all of the PI step classes
//!  \{ 
//!  \}

//! \defgroup  grouphelperpi Group PI Helpers 
//! \brief This group holds all of the group PI helper classes
//! \{ 
//! \}
//! \}

//! \defgroup uisteps UI Steps 
//! \brief This group holds all of UI classes
//! \{ 

//! \defgroup  highui High UI Steps 
//! \brief This group holds all of the high UI classes
//! \{ 
//! \}
//! \}

//! \defgroup othersetup Other Setup  
//! \brief This group holds all of the PI commands to control the intstruments themselves
//! \{ 

//! \defgroup dutsteps DUT Steps 
//! \brief This group holds all of the PI steps to control the DUT
//! \{ 
//! \}

//! \defgroup extsourcesteps External Source Steps 
//! \brief This group holds all of the PI steps to control the external source
//! \{ 
//! \}

//! \defgroup scopesteps Scope Steps 
//! \brief This group holds all of the PI steps to control the scope
//! \{ 
//! \}
//! \}


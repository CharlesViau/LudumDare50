using System;
using UnityEngine;
using General;

public class AnimationStatePlayer : IUpdatable
{
    //Variables
    private readonly Animator _animator;
    private readonly Rigidbody _rb;
    private readonly float _maxSpeed;
    private int _speedHash;

    public AnimationStatePlayer(Player player)
    {
        _rb = player.rb;
        _animator = player.animator;
        _maxSpeed = player.speed;
    }
    
    // Start is called before the first frame update
    public void Init()
    {
        _speedHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    public void PostInit()
    {
        
    }

    public void Refresh()
    {
        _animator.SetFloat(_speedHash, (_rb.velocity.magnitude/_maxSpeed));
    }

    public void FixedRefresh()
    {
        
    }

    public void LateRefresh()
    {
        
    }
}
